using System.Collections.Generic;

namespace Core.Events
{
    public interface IEventAggregate /*: IAggregate*/
    {
        Queue<IEvent> PendingEvents { get; }
    }
}
