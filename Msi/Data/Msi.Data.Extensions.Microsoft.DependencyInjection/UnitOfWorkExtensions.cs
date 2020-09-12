using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Msi.Core;
using Msi.Data.Abstractions;
using System;

namespace Msi.Data.Extensions.Microsoft.DependencyInjection
{
    public static class UnitOfWorkExtensions
    {

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, Action<UnitOfWorkOptions> options)
        {
            var provider = services.BuildServiceProvider();
            var config = provider.GetService<IConfiguration>();
            var logger = provider.GetService<ILoggerFactory>().CreateLogger(typeof(UnitOfWorkExtensions));

            var accessor = provider.GetService<IHttpContextAccessor>();
            UnitOfWorkAccessor.Initialize(() => accessor.HttpContext.RequestServices.GetService);

            services.AddScoped<ServiceFactory>(x => x.GetService);

            services.Configure<DataContextOptions>(x =>
            {
                x.ConnectionString = config.GetConnectionString("Default");
            });

            UnitOfWorkOptions _options = new UnitOfWorkOptions();
            options.Invoke(_options);

            services.Add(new ServiceDescriptor(typeof(IDataContext), _options.DataContextType, ServiceLifetime.Scoped));

            services.Add(new ServiceDescriptor(typeof(IUnitOfWork), _options.UnitOfWorkType, ServiceLifetime.Scoped));

            try
            {
                //provider = services.BuildServiceProvider();
                //var dataContext = provider.GetService<IDataContext>();
                //(dataContext as DbContext)?.Database.Migrate();
                //logger.LogInformation($"---MIGRATE DONE--- at {DateTime.Now}");
            }
            catch (Exception e)
            {
                //logger.LogError($"---MIGRATE ERROR--- at {DateTime.Now}");
                //Exception ex = e;
                //while (ex != null)
                //{
                //    logger.LogError(ex.Message);
                //    ex = ex.InnerException;
                //}
                //logger.LogError($"---MIGRATE ERROR END --- at {DateTime.Now}");
            }
            return services;
        }

    }
}
