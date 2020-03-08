using Core.Web.Extensions;
using Core.Web.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Module.Payments.Domain;
using Module.Payments.Entities;

namespace Module.User
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services, ModuleInfo moduleInfo)
        {
            services.AddServices(options =>
            {
                options.ServiceAssemblies.Add(moduleInfo.Assembly);
                options.ConfigureBusOptions(busOptions =>
                {
                    busOptions.AddHandlerAssembly(moduleInfo.Assembly);
                    busOptions.AddHandlerAssembly(typeof(CreatePaymentCommand).Assembly);
                });
            });
            moduleInfo.DependentAssemblies.Add(typeof(Payment).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
