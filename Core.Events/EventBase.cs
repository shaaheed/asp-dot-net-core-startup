using Msi.UtilityKit;
using System;

namespace Core.Events
{
    public class EventBase : IEvent
    {

        public long Id { get; set; }
        public string Object { get; set; }
        public string ObjectId { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string Data { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual string GenerateType()
        {
            var type = GetType().Name.Replace("Event", "").ToLowerAndAppend();
            Type = type;
            return type;
        }
    }
}
