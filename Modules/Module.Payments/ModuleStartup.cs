using Core.Web.Extensions;
using Core.Web.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Module.Payments.Domain;
using Module.Payments.Entities;

namespace Module.User
{
    public class ModuleStartup : ModuleStartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            //services.AddServices(options =>
            //{
            //    options.ServiceAssemblies.Add(moduleInfo.Assembly);
            //    options.ConfigureBusOptions(busOptions =>
            //    {
            //        busOptions.AddHandlerAssembly(moduleInfo.Assembly);
            //        busOptions.AddHandlerAssembly(typeof(CreatePaymentCommand).Assembly);
            //    });
            //});
            Assemblies.Add(typeof(Payment).Assembly);
            base.ConfigureServices(services);
        }
    }
}
