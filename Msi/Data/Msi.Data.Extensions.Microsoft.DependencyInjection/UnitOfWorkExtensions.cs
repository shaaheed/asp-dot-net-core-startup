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

            UnitOfWorkOptions _options = new UnitOfWorkOptions();
            options.Invoke(_options);

            services.Configure<DataContextOptions>(x =>
            {
                x.ConnectionString = config.GetConnectionString("Default");
                x.MigrationsAssembly = _options.MigrationAssembly;
            });

            //services.Add(new ServiceDescriptor(typeof(IDataContext), _options.DataContextType, ServiceLifetime.Scoped));

            services.Add(new ServiceDescriptor(typeof(IUnitOfWork), _options.UnitOfWorkType, ServiceLifetime.Scoped));

            var implementations = Global.GetGenericImplementations(typeof(IUnitOfWorkPipeline<>));
            foreach (var item in implementations)
            {
                var arg = item.GetInterfaces()[0].GetGenericArguments()[0];
                var serviceType = typeof(IUnitOfWorkPipeline<>).MakeGenericType(arg);
                services.Add(new ServiceDescriptor(serviceType, item, ServiceLifetime.Scoped));
            }
            return services;
        }

    }
}
