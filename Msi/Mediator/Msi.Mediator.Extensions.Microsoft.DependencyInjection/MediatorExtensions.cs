using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Msi.Core;
using Msi.Mediator.Abstractions;
using System;

namespace Msi.Mediator.Extensions.Microsoft.DependencyInjection
{
    public static class MediatorExtensions
    {
        public static void AddMediator(this IServiceCollection services, Action<MediatorOptions> options)
        {
            MediatorOptions _options = new MediatorOptions();
            options.Invoke(_options);

            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IEventBus, EventBus>();

            if (_options.Assemblies == null || _options.Assemblies.Count <= 0)
                throw new ArgumentException($"{nameof(_options.Assemblies)} can not be null or empty");

            services.AddMediatR(_options.Assemblies.ToArray());

            // var assemblies = Global.GetGenericImplementations(typeof(ICommand<>));

            // Type handler
            // _services.AddScoped(typeof(IPipelineBehavior<,>), handler);
        }
    }
}
