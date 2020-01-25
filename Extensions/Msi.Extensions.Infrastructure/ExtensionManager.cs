using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Msi.Extensions.Infrastructure
{
    public static class ExtensionManager
    {
        private static ConcurrentDictionary<Type, IEnumerable<Type>> cachedTypes;

        public static IEnumerable<Assembly> Assemblies { get; private set; }

        public static void SetAssemblies(IEnumerable<Assembly> assemblies)
        {
            Assemblies = assemblies;
            cachedTypes = new ConcurrentDictionary<Type, IEnumerable<Type>>();
        }

        public static Type GetImplementation<T>(bool useCaching = false)
        {
            return GetImplementation<T>(null, useCaching);
        }

        public static Type GetImplementation<T>(Func<Assembly, bool> predicate, bool useCaching = false)
        {
            return GetImplementations<T>(predicate, useCaching).FirstOrDefault();
        }

        public static IEnumerable<Type> GetImplementations<T>(bool useCaching = false)
        {
            return GetImplementations<T>(null, useCaching);
        }

        public static IEnumerable<Type> GetImplementations<T>(Func<Assembly, bool> predicate, bool useCaching = false)
        {
            Type type = typeof(T);

            if (useCaching && cachedTypes.ContainsKey(type))
            {
                return cachedTypes[type];
            }

            List<Type> implementations = new List<Type>();

            var assemblies = GetAssemblies(predicate);
            foreach (Assembly assembly in assemblies)
            {
                if(assembly.FullName.StartsWith("Msi.Extensions.Persistence.DependencyInjection"))
                {

                }
                var exportedTypes = assembly.GetExportedTypes();
                foreach (Type exportedType in exportedTypes)
                {
                    if (type.GetTypeInfo().IsAssignableFrom(exportedType) && exportedType.GetTypeInfo().IsClass)
                    {
                        implementations.Add(exportedType);
                    }
                }
            }

            if (useCaching)
            {
                cachedTypes[type] = implementations;
            }

            return implementations;
        }

        public static T GetInstance<T>(bool useCaching = false)
        {
            return GetInstance<T>(null, useCaching, new object[] { });
        }

        public static T GetInstance<T>(bool useCaching = false, params object[] args)
        {
            return GetInstance<T>(null, useCaching, args);
        }

        public static T GetInstance<T>(Func<Assembly, bool> predicate, bool useCaching = false)
        {
            return GetInstances<T>(predicate, useCaching).FirstOrDefault();
        }

        public static T GetInstance<T>(Func<Assembly, bool> predicate, bool useCaching = false, params object[] args)
        {
            return GetInstances<T>(predicate, useCaching, args).FirstOrDefault();
        }

        public static IEnumerable<T> GetInstances<T>(bool useCaching = false)
        {
            return GetInstances<T>(null, useCaching, new object[] { });
        }

        public static IEnumerable<T> GetInstances<T>(bool useCaching = false, params object[] args)
        {
            return GetInstances<T>(null, useCaching, args);
        }

        public static IEnumerable<T> GetInstances<T>(Func<Assembly, bool> predicate, bool useCaching = false)
        {
            return GetInstances<T>(predicate, useCaching, new object[] { });
        }

        public static IEnumerable<T> GetInstances<T>(Func<Assembly, bool> predicate, bool useCaching = false, params object[] args)
        {
            List<T> instances = new List<T>();
            var implementations = GetImplementations<T>(predicate, useCaching);
            foreach (Type implementation in implementations)
            {
                if (!implementation.GetTypeInfo().IsAbstract)
                {
                    T instance = (T)Activator.CreateInstance(implementation, args);
                    instances.Add(instance);
                }
            }
            return instances;
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
