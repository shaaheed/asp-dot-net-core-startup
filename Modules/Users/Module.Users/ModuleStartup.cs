﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Msi.Web;

namespace Module.Accounts
{
    public class ModuleStartup : IModuleStartup
    {
        public void Configure(IApplicationBuilder app)
        {
            //
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddMediator(opt => opt.Assemblies.Add(typeof(CreateUserCommand).Assembly));
        }
    }
}
