using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Msi.Extensions.DependencyInjection.Abstractions;
using Msi.Extensions.Infrastructure;
using System;

namespace Msi.Extensions.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddExtensions(this IServiceCollection services)
        {
            services.AddExtensions(null);
        }

        public static void AddExtensions(this IServiceCollection services, string extensionsPath)
        {
            services.AddExtensions(extensionsPath, false, new AssemblyProvider(services.BuildServiceProvider()));
        }

        public static void AddExtensions(this IServiceCollection services, string extensionsPath, bool includingSubpaths)
        {
            services.AddExtensions(extensionsPath, includingSubpaths, new AssemblyProvider(services.BuildServiceProvider()));
        }

        public static void AddExtensions(this IServiceCollection services, string extensionsPath, IAssemblyProvider assemblyProvider)
        {
            services.AddExtensions(extensionsPath, false, assemblyProvider);
        }

        public static void AddExtensions(this IServiceCollection services, string extensionsPath, bool includingSubpaths, IAssemblyProvider assemblyProvider)
        {
            DiscoverAssemblies(assemblyProvider, extensionsPath, includingSubpaths);

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ILogger logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger("Msi.Extensions.DependencyInjection");

            var registrars = ExtensionManager.GetInstances<IDependencyRegistrar>(false, new object[] { services, serviceProvider });
            foreach (IDependencyRegistrar registrar in registrars)
            {
                logger.LogInformation("Executing ConfigureServices action '{0}'", registrar.GetType().FullName);
                registrar.Register();
                serviceProvider = services.BuildServiceProvider();
            }
        }

        private static void DiscoverAssemblies(IAssemblyProvider assemblyProvider, string extensionsPath, bool includingSubpaths)
        {
            ExtensionManager.SetAssemblies(assemblyProvider.GetAssemblies(extensionsPath, includingSubpaths));
        }
    }
}
