using Core.Web.Extensions;
using Core.Web.Modules;
using Microsoft.Extensions.DependencyInjection;
using Module.Sales.Domain.Products;
using Module.Sales.Entities;

namespace Module.Sales
{
    public class ModuleInitializer : BaseModuleInitializer
    {
        public override void ConfigureServices(IServiceCollection services, ModuleInfo moduleInfo)
        {
            services.AddServices(options =>
            {
                options.ServiceAssemblies.Add(moduleInfo.Assembly);
                options.ConfigureBusOptions(busOptions =>
                {
                    busOptions.AddHandlerAssembly(moduleInfo.Assembly);
                    busOptions.AddHandlerAssembly(typeof(CreateProductCommand).Assembly);
                });
            });
            moduleInfo.DependentAssemblies.Add(typeof(Product).Assembly);
        }
    }
}
