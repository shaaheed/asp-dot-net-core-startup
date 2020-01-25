using Core.Web.Extensions;
using Core.Web.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Module.User
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services, ModuleInfo moduleInfo)
        {
           
            services.AddServices(options =>
            {
                options.ServiceAssemblies.Add(moduleInfo.Assembly);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
