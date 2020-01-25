using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Web.Modules
{
    public interface IModuleInitializer
    {
        void ConfigureServices(IServiceCollection services, ModuleInfo moduleInfo);

        void Configure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
