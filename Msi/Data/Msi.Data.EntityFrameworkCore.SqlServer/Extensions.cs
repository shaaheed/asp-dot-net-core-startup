using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Msi.Data.Abstractions;

namespace Msi.Data.EntityFrameworkCore.SqlServer
{
    public static class Extensions
    {

        public static IServiceCollection UseSqlServer(this IServiceCollection services)
        {
            services.AddDbContext<IDataContext, DataContext>(ServiceLifetime.Scoped);
            return services;
        }

        public static IServiceCollection Migrate(this IServiceCollection services)
        {
            ILogger logger = null;
            try
            {
                var provider = services.BuildServiceProvider();
                logger = provider.GetService<ILoggerFactory>().CreateLogger(typeof(Extensions));
                var dataContext = provider.GetService<IDataContext>();
                (dataContext as DbContext)?.Database.Migrate();
                logger.LogInformation($"---MIGRATE DONE--- at {DateTime.Now}");
            }
            catch (Exception e)
            {
                logger.LogError($"---MIGRATE ERROR--- at {DateTime.Now}");
                Exception ex = e;
                while (ex != null)
                {
                    logger.LogError(ex.Message);
                    ex = ex.InnerException;
                }
                logger.LogError($"---MIGRATE ERROR END --- at {DateTime.Now}");
            }
            return services;
        }

    }
}
