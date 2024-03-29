using Msi.Data.EntityFrameworkCore.SqlServer;
using Msi.Data.Extensions.Microsoft.DependencyInjection;
using Msi.Data.EntityFrameworkCore;
using Msi.Core;
using Msi.Web;
using Msi.Service.Extensions.Microsoft.DependencyInjection;
using Msi.Mediator.Extensions.Microsoft.DependencyInjection;
using Module.Systems.Exceptions;
using Module.Systems.Filters;
using Msi.Mediator.Abstractions;
using Module.Tokens.Domain;
using Services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.AspNetCore.Builder;

namespace AccountingWebHost
{
    public class Startup
    {

        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:4200")
                    .WithOrigins("http://othoba.xyz:4200")
                    .WithOrigins("http://othoba.xyz")
                    .WithOrigins("https://shaaheed.github.io")
                    .AllowCredentials();
                });
            });

            Global.Initialize(new DefaultAssemblyProvider(), _env.EnvironmentName);
            //services.AddSwaggerService();
            services.AddSwaggerGen(options =>
            {
                string version = "v1";
                options.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = "API",
                    Version = version
                });
            });

            var assemblies = Global.GetGenericImplementations(typeof(IQuery<>)).Select(x => x.Assembly).Distinct();
            services.AddMediator(opt =>
            {
                opt.Assemblies.AddRange(assemblies);
            });

            services.AddScoped<ITokenService, TokenService>();
            services.AddServices();
            services.AddModules();

            services.UseSqlServer();
            services.AddUnitOfWork(options =>
            {
                options.MigrationAssembly = GetType().Assembly.FullName;
                options.UseEntityFrameworkCore()/*.UseSqlServer(services)*/;
            });
            services.Migrate();

            //services.AddExtensions();

            services.AddAuthentication();
            //.AddJwtBearer("Bearer", options =>
            //{
            //    options.Authority = "https://localhost:44388";
            //    options.RequireHttpsMetadata = false;
            //    options.Audience = "WebAPI";
            //})
            //.AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
            //{
            //    options.Authority = "https://localhost:44388";
            //    options.RequireHttpsMetadata = false;
            //    options.ApiName = "WebAPI";
            //});

            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            //    options.LoginPath = PathString.FromUriComponent(new Uri("http://localhost:4200/login"));
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});

            //services.AddCorePersistence<CoreEFDataContext, CoreDatabaseOptions>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new ExceptionHandler());
                options.Filters.Add(new UnitOfWorkCommitFilter());
            }).AddNewtonsoftJson();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("default");
            //app.UseSwaggerService();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API"));

            app.UseModules();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSpa(options =>
            //{
            //});

        }
    }
}
