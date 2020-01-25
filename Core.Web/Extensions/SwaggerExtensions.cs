using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Core.Web.Extensions
{
    public static class SwaggerExtensions
    {

        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                string version = "v1";
                options.SwaggerDoc(version, new Info
                {
                    Title = "Comment API",
                    Version = version
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerService(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Comment API");
            });
            return app;
        }

    }
}
