using Core.Interfaces.Entities;

namespace Module.Core.Entities
{
    public class StateOrProvince : BaseEntity
    {
        public string CountryId { get; set; }

        public Country Country { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
