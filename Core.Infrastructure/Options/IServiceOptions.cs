using Core.Infrastructure.Bus;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Core.Infrastructure.Options
{
    public interface IServiceOptions
    {

        List<Assembly> ServiceAssemblies { get; }

        IServiceOptions ConfigureBusOptions(Action<IBusOptions> busOptions);

    }
}
