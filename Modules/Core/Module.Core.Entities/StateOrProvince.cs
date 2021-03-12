using System;

namespace Module.Core.Entities
{
    public class StateOrProvince : CodeNameEntity
    {
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string Type { get; set; }
    }
}
