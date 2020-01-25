using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Events
{
    public class EventAggregate : IEventAggregate
    {

        [JsonIgnore]
        public Queue<IEvent> PendingEvents { get; private set; }

        protected EventAggregate()
        {
            PendingEvents = new Queue<IEvent>();
        }

        public void Append(IEvent @event)
        {
            PendingEvents.Enqueue(@event);
        }

    }
}
