using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Infrastructure.Services
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ServiceLifetimeAttribute : Attribute
    {

        public ServiceLifetime ServiceLifetime { get; private set; }

        public ServiceLifetimeAttribute(ServiceLifetime serviceLifetime)
        {
            ServiceLifetime = serviceLifetime;
        }

    }
}
