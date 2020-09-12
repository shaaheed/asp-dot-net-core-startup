using Core.Web.Modules;
using Microsoft.Extensions.DependencyInjection;
using Module.Core.Entities;

namespace Module.Core
{
    public class ModuleStartup : ModuleStartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<IHttpContextAccessor>();
            Assemblies.Add(typeof(Address).Assembly);
            base.ConfigureServices(services);
        }
    }
}
