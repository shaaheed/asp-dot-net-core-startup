using Core.Web.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Module.User
{
    public class ModuleInitializer : BaseModuleInitializer
    {
        public override void ConfigureServices(IServiceCollection services, ModuleInfo moduleInfo)
        {
            moduleInfo.DependentAssemblies.Add(typeof(Users.Entities.User).Assembly);
            base.ConfigureServices(services, moduleInfo);
        }
    }
}
