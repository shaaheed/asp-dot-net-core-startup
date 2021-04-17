using Msi.Data.Entity;
using Module.Systems.Entities;
using System;

namespace Module.Organizations.Entities
{
    public class Branch : OrganizationBaseEntity
    {
        public Branch() { }

        public Branch(Guid id)
        {
            Id = id;
        }

        public string Name { get; set; }
        public string Email { get; set; }

        public Guid? CountryId { get; set; }
        public Country Country { get; set; }

        public Guid? CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
