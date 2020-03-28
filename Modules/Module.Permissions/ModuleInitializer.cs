using Core.Web.Extensions;
using Core.Web.Modules;
using Microsoft.Extensions.DependencyInjection;
using Module.Permissions.Data;
using Module.Permissions.Entities;

namespace Module.Permissions
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
                    busOptions.AddHandlerAssembly(typeof(CreatePermissionCommand).Assembly);
                });
            });
            moduleInfo.DependentAssemblies.Add(typeof(Permission).Assembly);
        }
    }
}
