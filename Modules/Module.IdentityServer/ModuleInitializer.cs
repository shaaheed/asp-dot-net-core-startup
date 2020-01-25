//using Core.Web.Modules;
//using IdentityServer4.Configuration;
//using IdentityServer4.EntityFramework.Options;
//using IdentityServer4.EntityFramework.Stores;
//using IdentityServer4.Stores;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Module.IdentityServer.Data;

//namespace Module.IdentityServer
//{

//    public class ModuleInitializer : BaseModuleInitializer
//    {
//        public override void ConfigureServices(IServiceCollection services, ModuleInfo moduleInfo)
//        {

//            var storeOptions = new ConfigurationStoreOptions();
//            services.AddSingleton(storeOptions);
//            //services.AddPersistence<IdentityDataContext, IdentityDatabaseOptions>();
//            //services.AddPersistence<IdentityServerDataContext, IdentityServerDatabaseOptions>();
//            //services.AddDbContext<IConfigurationDbContext, ConfigurationDbContext>();

//            services.AddIdentity<User, Role>(options =>
//            {
//                options.User.RequireUniqueEmail = true;
//            })
//                .AddUserStore<UserStore<User, Role, IdentityDataContext, long, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>>()
//                .AddRoleStore<RoleStore<Role, IdentityDataContext, long, UserRole, RoleClaim>>()
//                .AddEntityFrameworkStores<IdentityServerDataContext>()
//                .AddDefaultTokenProviders();

//            //services.AddTransient<IClientStore, ClientStore>();
//            //services.AddTransient<IResourceStore, ResourceStore>();

//            services.AddIdentityServer(options =>
//            {
//                options.Events.RaiseSuccessEvents = true;
//                options.Events.RaiseFailureEvents = true;
//                options.Events.RaiseErrorEvents = true;
//                options.Events.RaiseInformationEvents = true;

//                options.Endpoints.EnableAuthorizeEndpoint = true;

//                options.UserInteraction = new UserInteractionOptions
//                {
//                    LoginUrl = "http://localhost:4200/login",
//                    ErrorUrl = "http://localhost:4200/error",
//                    LogoutUrl = "http://localhost:4200/logout"
//                };
//                //options.Authentication.CookieAuthenticationScheme = "Cookies";
//                //options.Authentication.CookieAuthenticationScheme = IdentityServerConstants.DefaultCookieAuthenticationScheme;
//                //options.Cors.CorsPaths.Add(new PathString("/Account/Login"));
//            })
//                .AddAspNetIdentity<User>()
//                //.AddClientStore<ClientStore>()
//                //.AddResourceStore<ResourceStore>()
//                //.AddConfigurationStore<IdentityServerDataContext>()
//                .AddDeveloperSigningCredential();

//            base.ConfigureServices(services, moduleInfo);

//        }

//        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            app.UseIdentityServer();
//        }
//    }
//}
