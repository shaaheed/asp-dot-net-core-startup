using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Core.Web.Modules;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using Module.Core.Exceptions;
using Msi.Extensions.Persistence.Abstractions;
using Module.Core.Filters;
using Msi.Extensions.DependencyInjection.Extensions;

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
            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:4200")
                    .WithOrigins("https://asp-dot-net-core-startup.herokuapp.com")
                    .AllowCredentials();
                });
            });


            services.AddDataProtection()
                .SetApplicationName("data_protection_app")
                //.ProtectKeysWithCertificate()
                .PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory()));

            //services.AddSwaggerService();
            services.AddModules(_env.ContentRootPath);

            services.Configure<DataContextOptions>(options =>
            {
                options.ConnectionString = Configuration.GetConnectionString("Default");
                options.MigrationsAssembly = GetType().Assembly.FullName;
            });
            services.AddExtensions();

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

            services.AddControllers(options =>
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
