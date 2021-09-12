using Module.Systems.Entities;
using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class ContactPerson : OrganizationEntity
    {
        public bool IsPrimary { get; set; }
        public Guid ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

    }
}
