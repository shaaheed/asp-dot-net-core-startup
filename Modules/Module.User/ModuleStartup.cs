using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Msi.Web;
using Msi.Mediator.Extensions.Microsoft.DependencyInjection;
using Module.Users.Domain;

namespace Module.User
{
    public class ModuleStartup : IModuleStartup
    {
        public void Configure(IApplicationBuilder app)
        {
            //
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediator(opt => opt.Assemblies.Add(typeof(CreateUserCommand).Assembly));
        }
    }
}
