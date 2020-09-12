using System.Collections.Generic;

namespace Msi.Mediator.Abstractions
{
    public interface IEventAggregate /*: IAggregate*/
    {
        Queue<IEvent> PendingEvents { get; }
    }
}
