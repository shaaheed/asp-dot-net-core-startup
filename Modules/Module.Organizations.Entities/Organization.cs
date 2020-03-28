using Core.Interfaces.Entities;
using Module.Core.Entities;

namespace Module.Organizations.Entities
{
    public class Organization : BaseEntity
    {
        public Organization() { }

        public Organization(long id)
        {
            Id = id;
        }

        public string Name { get; set; }

        public long? TypeId { get; set; }
        public OrganizationType Type { get; set; }

        public long? CountryId { get; set; }
        public Country Country { get; set; }

        public long? CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public long? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
