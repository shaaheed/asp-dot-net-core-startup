using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Msi.Core
{
    public class Global
    {
        public static string Environment { get; private set; }
        public static IEnumerable<Assembly> Assemblies { get; private set; }

        private static ConcurrentDictionary<Type, IEnumerable<Type>> cachedTypes;
        private static IAssemblyProvider _assemblyProvider;

        public static void Initialize(IAssemblyProvider assemblyProvider, string environment)
        {
            Environment = environment;
            cachedTypes = new ConcurrentDictionary<Type, IEnumerable<Type>>();
            _assemblyProvider = assemblyProvider;
            Assemblies = _assemblyProvider.GetAssemblies(string.Empty, false);
        }

        public static Type GetImplementation<T>(bool useCaching = false)
        {
            return GetImplementation<T>(null, useCaching);
        }

        public static Type GetImplementation<T>(Func<Assembly, bool> predicate, bool useCaching = false)
        {
            return GetImplementations<T>(predicate, useCaching).FirstOrDefault();
        }

        public static IEnumerable<Type> GetImplementations(Type type, bool useCaching = false)
        {
            return GetImplementations(type, null, useCaching);
        }

        public static IEnumerable<Type> GetImplementations<T>(bool useCaching = false)
        {
            return GetImplementations<T>(null, useCaching);
        }

        public static IEnumerable<Type> GetGenericImplementations(Type type, Func<Assembly, bool> predicate = null, bool useCaching = false)
        {

            if (useCaching && cachedTypes.ContainsKey(type))
            {
                return cachedTypes[type];
            }

            List<Type> implementations = new List<Type>();

            var assemblies = GetAssemblies(predicate);
            foreach (Assembly assembly in assemblies)
            {
                var exportedTypes = assembly.GetExportedTypes();
                foreach (Type exportedType in exportedTypes)
                {
                    var interfaces = exportedType.GetInterfaces().Where(x => x.IsGenericType);
                    foreach (var @interface in interfaces)
                    {
                        if (@interface.GetGenericTypeDefinition() == type)
                        {
                            implementations.Add(exportedType);
                        }
                    }
                }
            }

            if (useCaching)
            {
                cachedTypes[type] = implementations;
            }

            return implementations;
        }

        public static IEnumerable<Type> GetImplementations(Type type, Func<Assembly, bool> predicate, bool useCaching = true)
        {
            if (useCaching && cachedTypes.ContainsKey(type))
            {
                foreach (var item in cachedTypes[type])
                {
                    yield return item;
                }
            }

            List<Type> implementations = new List<Type>();
            var assemblies = GetAssemblies(predicate);
            foreach (Assembly assembly in assemblies)
            {
                var exportedTypes = assembly.GetExportedTypes();
                foreach (Type exportedType in exportedTypes)
                {
                    if (type.GetTypeInfo().IsAssignableFrom(exportedType) && exportedType.GetTypeInfo().IsClass)
                    {
                        implementations.Add(exportedType);
                        yield return exportedType;
                    }
                }
            }
            if (useCaching)
            {
                cachedTypes[type] = implementations;
            }
        }

        public static IEnumerable<Type> GetImplementations<T>(Func<Assembly, bool> predicate, bool useCaching = true)
        {
            return GetImplementations(typeof(T), predicate, useCaching);
        }

        public static T GetInstance<T>(bool useCaching = false)
        {
            return GetInstance<T>(null, useCaching, new object[] { });
        }

        public static T GetInstance<T>(bool useCaching = false, params object[] args)
        {
            return GetInstance<T>(null, useCaching, args);
        }

        public static T GetInstance<T>(Func<Assembly, bool> predicate, bool useCaching = true)
        {
            return GetInstances<T>(predicate, useCaching).FirstOrDefault();
        }

        public static T GetInstance<T>(Func<Assembly, bool> predicate, bool useCaching = true, params object[] args)
        {
            return GetInstances<T>(predicate, useCaching, args).FirstOrDefault();
        }

        public static IEnumerable<T> GetInstances<T>(bool useCaching = true)
        {
            return GetInstances<T>(null, useCaching, new object[] { });
        }

        public static IEnumerable<T> GetInstances<T>(bool useCaching = true, params object[] args)
        {
            return GetInstances<T>(null, useCaching, args);
        }

        public static IEnumerable<T> GetInstances<T>(Func<Assembly, bool> predicate, bool useCaching = true)
        {
            return GetInstances<T>(predicate, useCaching, new object[] { });
        }

        public static IEnumerable<T> GetInstances<T>(Func<Assembly, bool> predicate, bool useCaching = true, params object[] args)
        {
            var implementations = GetImplementations<T>(predicate, useCaching);
            foreach (Type implementation in implementations)
            {
                if (!implementation.GetTypeInfo().IsAbstract)
                {
                    T instance = (T)Activator.CreateInstance(implementation, args);
                    yield return instance;
                }
            }
        }

        private static IEnumerable<Assembly> GetAssemblies(Func<Assembly, bool> predicate)
        {
            if (predicate == null)
            {
                return Assemblies;
            }
            return Assemblies.Where(predicate);
        }
    }
}
