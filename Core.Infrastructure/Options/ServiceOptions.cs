using Core.Infrastructure.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Core.Infrastructure.Options
{
    public class ServiceOptions : IServiceOptions
    {
        public List<Assembly> ServiceAssemblies { get; }

        private readonly IBusOptions _busOptions;
        private readonly IServiceCollection _services;

        public ServiceOptions(IServiceCollection services)
        {
            _services = services;
            _busOptions = new BusOptions(services);
            ServiceAssemblies = new List<Assembly>();
        }

        public IServiceOptions ConfigureBusOptions(Action<IBusOptions> options)
        {
            options?.Invoke(_busOptions);
            return this;
        }

    }
}
