using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Core.Infrastructure.Bus
{
    public class BusOptions : IBusOptions
    {

        private readonly IServiceCollection _services;

        public BusOptions(IServiceCollection services)
        {
            _services = services;
        }

        public IBusOptions AddHandlerAssembly(Assembly assembly)
        {
            _services.AddMediatR(new Assembly[] { assembly });
            return this;
        }

        public IBusOptions AddHandlerAssemblyMarkerType(Type type)
        {
            _services.AddMediatR(new Type[] { type });
            return this;
        }

        public IBusOptions AddGenericBehaviourHandler(Type handler)
        {
            _services.AddScoped(typeof(IPipelineBehavior<,>), handler);
            return this;
        }

    }
}
