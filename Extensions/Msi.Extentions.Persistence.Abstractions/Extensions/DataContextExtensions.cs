using Msi.Extensions.Persistence.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Msi.Extensions.Persistence.Extensions
{
    public static class DataContextExtensions
    {

        #region Generic Persistence
        public static IServiceCollection AddPersistence<TDataContext, TDataContextOptions>(this IServiceCollection services)
    where TDataContext : DbContext, IDataContext
    where TDataContextOptions : class, IConnectionStringOptions, new()
        {
            return services.AddPersistence(typeof(TDataContext), typeof(TDataContextOptions));
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, Type dataContextType, Type dataContextOptionsType)
        {
            string connectionString = services.GetConnectionString(dataContextOptionsType);
            return services.AddPersistence(dataContextType, connectionString);
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, Type dataContextType, string connectionString)
        {
            services.AddUnitOfWorkOfT(dataContextType, connectionString);
            return services;
        }

        #endregion

        #region Core Persistence
        public static IServiceCollection AddCorePersistence<TDataContext, TDataContextOptions>(this IServiceCollection services)
    where TDataContext : DbContext, IEFDataContext
    where TDataContextOptions : class, IConnectionStringOptions, new()
        {
            return services.AddCorePersistence(typeof(TDataContext), typeof(TDataContextOptions));
        }

        public static IServiceCollection AddCorePersistence(this IServiceCollection services, Type dataContextType, Type dataContextOptionsType)
        {
            string connectionString = services.GetConnectionString(dataContextOptionsType);
            return services.AddCorePersistence(dataContextType, connectionString);
        }

        public static IServiceCollection AddCorePersistence(this IServiceCollection services, Type dataContextType, string connectionString)
        {
            services.AddUnitOfWork(dataContextType, connectionString);
            return services;
        }
        #endregion

        public static string GetConnectionString(this IServiceCollection services, Type dataContextOptionsType)
        {
            string connectionStringKey = $"{dataContextOptionsType.Name}:{nameof(IConnectionStringOptions.ConnectionString)}";
            var connectionString = services.GetConfiguration().GetValue<string>(connectionStringKey);
            return connectionString;
        }

        public static DbContextOptionsBuilder UseDefaultSqlServer(this DbContextOptionsBuilder options, string connectionString, string migrationAssembly)
        {
            options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
                sqlOptions.MigrationsAssembly(migrationAssembly);
            })
                    .ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
            return options;
        }

        // looking for bellow signature method
        // public static IServiceCollection AddDbContext<TContextService, TContextImplementation>([NotNullAttribute] this IServiceCollection serviceCollection, [CanBeNullAttribute] Action<DbContextOptionsBuilder> optionsAction = null, ServiceLifetime contextLifetime = ServiceLifetime.Scoped, ServiceLifetime optionsLifetime = ServiceLifetime.Scoped) where TContextImplementation : DbContext, TContextService;
        private static MethodInfo GetMethodAddDbContextMethod2()
        {
            return typeof(EntityFrameworkServiceCollectionExtensions)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .FirstOrDefault(methodInfo =>
                {
                    var parameters = methodInfo.GetParameters();
                    if (methodInfo.GetGenericArguments().Count() == 2
                    && parameters.Count() == 4
                    && parameters[1].ParameterType == typeof(Action<DbContextOptionsBuilder>)
                    && parameters[2].ParameterType == typeof(ServiceLifetime)
                    && parameters[3].ParameterType == typeof(ServiceLifetime))
                    {
                        return true;
                    }
                    return false;
                });
        }

        // looking for bellow signature method
        // public static IServiceCollection AddDbContext<TContext>([NotNullAttribute] this IServiceCollection serviceCollection, [CanBeNullAttribute] Action<DbContextOptionsBuilder> optionsAction = null, ServiceLifetime contextLifetime = ServiceLifetime.Scoped, ServiceLifetime optionsLifetime = ServiceLifetime.Scoped) where TContext : DbContext;
        private static MethodInfo GetMethodAddDbContextMethod()
        {
            return typeof(EntityFrameworkServiceCollectionExtensions)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .FirstOrDefault(methodInfo =>
                {
                    var parameters = methodInfo.GetParameters();
                    if (methodInfo.GetGenericArguments().Count() == 1
                    && parameters.Count() == 4
                    && parameters[1].ParameterType == typeof(Action<DbContextOptionsBuilder>)
                    && parameters[2].ParameterType == typeof(ServiceLifetime)
                    && parameters[3].ParameterType == typeof(ServiceLifetime))
                    {
                        return true;
                    }
                    return false;
                });
        }

        // public static IServiceCollection AddDbContextPool<TContextService, TContextImplementation>([NotNullAttribute] this IServiceCollection serviceCollection, [NotNullAttribute] Action<DbContextOptionsBuilder> optionsAction, int poolSize = 128) where TContextService : class where TContextImplementation : DbContext, TContextService;
        private static MethodInfo GetMethodAddDbContextPoolMethod()
        {
            return typeof(EntityFrameworkServiceCollectionExtensions)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .FirstOrDefault(methodInfo =>
                {
                    var parameters = methodInfo.GetParameters();
                    if (methodInfo.GetGenericArguments().Count() == 2
                    && parameters.Count() == 3
                    && parameters[1].ParameterType == typeof(Action<DbContextOptionsBuilder>)
                    && parameters[2].ParameterType == typeof(int))
                    {
                        return true;
                    }
                    return false;
                });
        }

        private static IConfiguration GetConfiguration(this IServiceCollection services)
        {
            return services.BuildServiceProvider().GetService<IConfiguration>();
        }

        private static void AddUnitOfWorkOfT(this IServiceCollection services, Type dataContextType, string connectionString)
        {
            var unitOfWorkInterfaceType = typeof(IUnitOfWork<>).MakeGenericType(dataContextType);
            services.AddTransient(unitOfWorkInterfaceType, serviceProvider =>
            {
                var scope = serviceProvider.CreateScope();
                var dataContext = scope.ServiceProvider.GetService(dataContextType);
                if (dataContext == null)
                {
                    throw new ArgumentNullException(nameof(dataContext));
                }
                var unitOfWorkType = typeof(UnitOfWork<>).MakeGenericType(dataContextType);
                return ActivatorUtilities.CreateInstance(serviceProvider, unitOfWorkType, dataContext);
            });

            var addDbContextMethod = GetMethodAddDbContextMethod();
            if (addDbContextMethod == null)
            {
                throw new ArgumentNullException(nameof(addDbContextMethod));
            }
            var genericAddDbContextMethod = addDbContextMethod.MakeGenericMethod(dataContextType);

            var dbContextOptionsBuilder = GetDbContextOptionsBuilder(connectionString, dataContextType);
            genericAddDbContextMethod.Invoke(null, new object[] { services, dbContextOptionsBuilder, ServiceLifetime.Scoped, ServiceLifetime.Scoped });
        }

        private static void AddUnitOfWork(this IServiceCollection services, Type dataContextType, string connectionString)
        {
            services.AddTransient<IUnitOfWork>(serviceProvider =>
            {
                var scope = serviceProvider.CreateScope();
                var dataContext = scope.ServiceProvider.GetService(dataContextType);
                if (dataContext == null)
                {
                    throw new ArgumentNullException(nameof(dataContext));
                }
                return ActivatorUtilities.CreateInstance<UnitOfWork>(serviceProvider, dataContext);
            });

            //var addDbContextPoolMethod = GetMethodAddDbContextPoolMethod();

            //if (addDbContextPoolMethod != null)
            //{
            //    var dbContextOptionsBuilder = GetDbContextOptionsBuilder(connectionString, dataContextType);
            //    addDbContextPoolMethod
            //        .MakeGenericMethod(typeof(IDataContext), dataContextType)
            //        .Invoke(null, new object[] {
            //            services, dbContextOptionsBuilder, 128
            //        });
            //}
            var addDbContextMethod = GetMethodAddDbContextMethod();
            if (addDbContextMethod == null)
            {
                throw new ArgumentNullException(nameof(addDbContextMethod));
            }

            var genericAddDbContextMethod = addDbContextMethod.MakeGenericMethod(dataContextType);
            var dbContextOptionsBuilder = GetDbContextOptionsBuilder(connectionString, dataContextType);
            genericAddDbContextMethod.Invoke(null, new object[] { services, dbContextOptionsBuilder, ServiceLifetime.Scoped, ServiceLifetime.Scoped });
        }

        private static Action<DbContextOptionsBuilder> GetDbContextOptionsBuilder(string connectionString, Type dataContextType)
        {
            Action<DbContextOptionsBuilder> dbContextOptionsBuilder = options =>
            {
                if (connectionString == null)
                {
                    throw new ArgumentNullException(nameof(connectionString));
                }
                options.UseDefaultSqlServer(connectionString, dataContextType.Assembly.GetName().Name);

            };
            return dbContextOptionsBuilder;
        }

    }
}
