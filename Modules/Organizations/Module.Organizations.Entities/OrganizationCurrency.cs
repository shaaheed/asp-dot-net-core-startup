using Msi.Data.Entity;
using Module.Systems.Entities;
using System;

namespace Module.Organizations.Entities
{
    public class OrganizationCurrency : BaseEntity
    {
        public Guid OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        public Guid CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        public float ExchangeRate { get; set; }
    }
}
