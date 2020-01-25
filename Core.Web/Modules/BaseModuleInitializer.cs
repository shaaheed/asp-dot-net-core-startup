using Core.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Web.Modules
{
    public class BaseModuleInitializer : IModuleInitializer
    {
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }

        public virtual void ConfigureServices(IServiceCollection services, ModuleInfo moduleInfo)
        {
            services.AddServices(options =>
            {
                options.ServiceAssemblies.Add(moduleInfo.Assembly);
                options.ConfigureBusOptions(busOptions =>
                {
                    busOptions.AddHandlerAssembly(moduleInfo.Assembly);
                });
            });
        }
    }
}
