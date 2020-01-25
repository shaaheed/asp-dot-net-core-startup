using System;
using System.Reflection;

namespace Core.Infrastructure.Bus
{
    public interface IBusOptions
    {
        IBusOptions AddHandlerAssembly(Assembly assembly);

        IBusOptions AddHandlerAssemblyMarkerType(Type type);

        IBusOptions AddGenericBehaviourHandler(Type handler);
    }
}
