using Microsoft.Extensions.DependencyInjection;
using System;

namespace Msi.Extensions.DependencyInjection.Abstractions
{
    public abstract class DependencyRegistrarBase : IDependencyRegistrar
    {

        public IServiceCollection Services { get; private set; }
        public IServiceProvider Provider { get; private set; }

        public DependencyRegistrarBase(IServiceCollection services, IServiceProvider provider)
        {
            Services = services;
            Provider = provider;
        }

        public abstract void Register();

    }
}
