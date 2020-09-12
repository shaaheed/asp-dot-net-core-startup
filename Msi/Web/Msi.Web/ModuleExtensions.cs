using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Msi.Core;

namespace Msi.Web
{
    public static class ModuleExtensions
    {

        public static IServiceCollection AddModules(this IServiceCollection services)
        {
            var modules = Global.GetInstances<IModuleStartup>();
            foreach (var module in modules)
            {
                module.ConfigureServices(services);
            }
            return services;
        }

        public static IApplicationBuilder UseModules(this IApplicationBuilder application)
        {
            var modules = Global.GetInstances<IModuleStartup>();
            foreach (var module in modules)
            {
                module.Configure(application);
            }
            return application;
        }

    }
}
