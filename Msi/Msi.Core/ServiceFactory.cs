using System;
using System.Collections.Generic;

namespace Msi.Core
{
    public delegate object ServiceFactory(Type serviceType);

    public static class ServiceFactoryExtensions
    {
        public static T GetInstance<T>(this ServiceFactory factory)
            => (T)factory(typeof(T));

        public static IEnumerable<T> GetInstances<T>(this ServiceFactory factory)
            => (IEnumerable<T>)factory(typeof(IEnumerable<T>));

        public static object GetInstance(this ServiceFactory factory, Type serviceType)
            => factory(serviceType);

        public static IEnumerable<object> GetInstances(this ServiceFactory factory, Type serviceType)
        {
            var type = typeof(IEnumerable<>);
            type.MakeGenericType(serviceType);
            return (IEnumerable<object>)factory(type);
        }
    }
}
