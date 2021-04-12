using Msi.Data.Entity;
using Module.Systems.Entities;
using System;

namespace Module.Organizations.Entities
{
    public class Organization : BaseEntity
    {
        public Organization() { }

        public Organization(Guid id)
        {
            Id = id;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Owner { get; set; }
        public bool IsDefault { get; set; }

        public Guid? TypeId { get; set; }
        public OrganizationType Type { get; set; }

        public Guid? CountryId { get; set; }
        public Country Country { get; set; }

        public Guid? CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
