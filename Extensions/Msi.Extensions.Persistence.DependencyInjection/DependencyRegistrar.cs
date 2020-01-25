using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Msi.Extensions.DependencyInjection.Abstractions;
using Msi.Extensions.Infrastructure;
using Msi.Extensions.Persistence.Abstractions;
using Msi.Extensions.Persistence.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Msi.Extensions.Persistence.DependencyInjection
{
    public class DependencyRegistrar : DependencyRegistrarBase
    {
        public DependencyRegistrar(IServiceCollection services, IServiceProvider provider) : base(services, provider)
        {
        }

        public override void Register()
        {
            var types = ExtensionManager.GetImplementations<IDataContext>()?.Where(t => !t.GetTypeInfo().IsAbstract);

            var config = Provider.GetService<IConfiguration>();
            Services.Configure<DataContextOptions>(options =>
            {
                options.ConnectionString = config.GetConnectionString("Default");
            });

            #region Comment
            //if (type == null)
            //{
            //    ILogger logger = _provider.GetService<ILoggerFactory>().CreateLogger("ExtCore.Data.Dapper");

            //    logger.LogError("Implementation of ExtCore.Data.Abstractions.IStorageContext not found");
            //    return;
            //}
            //foreach (var type in types)
            //{
            //    if(!type.Name.Contains("IdentityDataContext") && !type.Name.Contains("IdentityServerDataContext"))
            //    {
            //      _container.AddPersistence();
            //    }
            //}
            #endregion

            Services.AddDbContext<IDataContext, EntityFrameworkCore.MySql.DataContext>(ServiceLifetime.Scoped);

            var migrators = ExtensionManager.GetInstances<IMigrator>();
            var dataContext = Services.BuildServiceProvider().GetService<IDataContext>();
            foreach (var migrator in migrators)
            {
                migrator.MigratorAsync(dataContext).ConfigureAwait(false);
            }

            //_container.AddScoped(typeof(IDataContext), typeof(EntityFrameworkCore.SqlServer.DataContext));
            var uowType = typeof(IUnitOfWork); //.MakeGenericType(typeof(TContext));
            Services.AddScoped(uowType, serviceProvider =>
            {
                return ActivatorUtilities.CreateInstance(serviceProvider, typeof(UnitOfWork));
            });
        }
    }
}
