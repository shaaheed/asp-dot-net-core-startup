using Microsoft.Extensions.DependencyInjection;
using Msi.Extensions.Persistence.Abstractions;
using System;

namespace Msi.Extensions.Persistence.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence<TContextService, TContextImplementation>(this IServiceCollection services)
        {
            services.AddPersistence(typeof(TContextService), typeof(TContextImplementation));
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, Type dataContext, Type dataContextImplementation)
        {
            services.AddScoped(dataContext, dataContextImplementation);
            var uowType = typeof(IUnitOfWork); //.MakeGenericType(typeof(TContext));
            services.AddScoped(uowType, serviceProvider =>
            {
                var _dataContext = serviceProvider.GetService(dataContext);
                return ActivatorUtilities.CreateInstance(serviceProvider, uowType, _dataContext);
            });
            return services;
        }
    }
}
