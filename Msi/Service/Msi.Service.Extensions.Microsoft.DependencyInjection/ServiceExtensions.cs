using Microsoft.Extensions.DependencyInjection;
using Msi.Core;
using Msi.Service.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Msi.Service.Extensions.Microsoft.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            var _services = Global.GetImplementations<IService>();

            var typeInfos = _services.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);

            foreach (var implementationTypeInfo in typeInfos)
            {
                var interfaces = implementationTypeInfo.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                services.AddServicesInternal(nameof(ITransientService), interfaces, implementationTypeInfo, ServiceLifetime.Transient);

                services.AddServicesInternal(nameof(ISingletonService), interfaces, implementationTypeInfo, ServiceLifetime.Singleton);

                services.AddServicesInternal(nameof(IScopedService), interfaces, implementationTypeInfo, ServiceLifetime.Scoped);
            }
        }

        private static void AddServicesInternal(this IServiceCollection services, string service, IEnumerable<TypeInfo> interfaces, TypeInfo implementationTypeInfo, ServiceLifetime lifetime)
        {
            foreach (var handlerTypeInfo in interfaces.Where(x => x.GetInterface(service) != null))
            {
                // find attribute
                #region Comment
                //var serviceLifetimeAttribute = implementationTypeInfo.GetCustomAttribute<ServiceLifetimeAttribute>();
                //if (serviceLifetimeAttribute != null)
                //{
                //    var _lifetime = serviceLifetimeAttribute.ServiceLifetime;
                //    var descriptor = new ServiceDescriptor(handlerTypeInfo.AsType(), implementationTypeInfo.AsType(), _lifetime);
                //    services.Add(descriptor);
                //}
                //else
                //{
                //    var descriptor = new ServiceDescriptor(handlerTypeInfo.AsType(), implementationTypeInfo.AsType(), lifetime);
                //    services.Add(descriptor);
                //}
                #endregion
                var descriptor = new ServiceDescriptor(handlerTypeInfo.AsType(), implementationTypeInfo.AsType(), lifetime);
                services.Add(descriptor);
            }
        }

    }
}
