using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Msi.Web
{
    public class ModuleStartupBase : IModuleStartup
    {
        public virtual void Configure(IApplicationBuilder app)
        {
            //
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            
        }
    }
}
