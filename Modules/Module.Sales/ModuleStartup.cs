using Core.Web.Extensions;
using Core.Web.Modules;
using Microsoft.Extensions.DependencyInjection;
using Module.Sales.Domain.Products;
using Module.Sales.Entities;

namespace Module.Sales
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
            //        busOptions.AddHandlerAssembly(typeof(CreateProductCommand).Assembly);
            //    });
            //});
            Assemblies.Add(typeof(Product).Assembly);
        }
    }
}
