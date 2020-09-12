using Core.Web.Extensions;
using Core.Web.Modules;
using Microsoft.Extensions.DependencyInjection;
using Module.Permissions.Data;
using Module.Permissions.Entities;

namespace Module.Permissions
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
            //        busOptions.AddHandlerAssembly(typeof(CreatePermissionCommand).Assembly);
            //    });
            //});
            Assemblies.Add(typeof(Permission).Assembly);
        }
    }
}
