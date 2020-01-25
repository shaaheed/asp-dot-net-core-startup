using Core.Web.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Module.Core.Entities;
using Module.Core.Services;

namespace Module.Core
{
    public class ModuleInitializer : BaseModuleInitializer
    {
        public override void ConfigureServices(IServiceCollection services, ModuleInfo moduleInfo)
        {
            //services.Configure<IHttpContextAccessor>();
            moduleInfo.DependentAssemblies.Add(typeof(Address).Assembly);
            base.ConfigureServices(services, moduleInfo);
        }
    }
}
