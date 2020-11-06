//using Msi.Mediator.Abstractions;
//using Msi.Mediator.Abstractions;
//using Core.Infrastructure.Options;
//using Msi.Mediator.Abstractions;
//using Core.Infrastructure.Services;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Linq;
//using System.Reflection;

//namespace Msi.Web
//{
//    public static class ServiceCollectionExtensions
//    {

//        private static IServiceCollection _services;
//        private static IConfiguration _configuration;
//        private static IServiceOptions _serviceOptions;

//        public static IServiceCollection AddServices(this IServiceCollection services, Action<IServiceOptions> optionBuilder)
//        {
//            _services = services;
//            _serviceOptions = new ServiceOptions(services);
//            optionBuilder?.Invoke(_serviceOptions);

//            BuildOptions();
//            return services;
//        }

//        public static IServiceOptions SetConfiguration(this IServiceOptions builder, IConfiguration configuration)
//        {
//            _configuration = configuration;
//            return builder;
//        }

//        private static void BuildOptions()
//        {
//            _services.AddTransient<IQueryBus, QueryBus>();
//            _services.AddTransient<ICommandBus, CommandBus>();
//            _services.AddTransient<IEventBus, EventBus>();
//            AddServicesInternal();
//        }

//        private static void AddServicesInternal()
//        {
//            foreach (var assembly in _serviceOptions.ServiceAssemblies)
//            {
//                var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);

//                foreach (var implementationType in classTypes)
//                {
//                    var interfaces = implementationType.ImplementedInterfaces.Select(i => i.GetTypeInfo());
//                    foreach (var handlerType in interfaces.Where(x => x.GetInterface(nameof(IService)) != null))
//                    {
//                        var serviceLifetimeAttribute = implementationType.GetCustomAttribute<ServiceLifetimeAttribute>();
//                        var lifetime = ServiceLifetime.Transient;
//                        if (serviceLifetimeAttribute != null)
//                        {
//                            lifetime = serviceLifetimeAttribute.ServiceLifetime;
//                        }
//                        var descriptor = new ServiceDescriptor(handlerType.AsType(), implementationType.AsType(), lifetime);
//                        _services.Add(descriptor);
//                    }
//                }
//            }
//        }

//    }
//}
