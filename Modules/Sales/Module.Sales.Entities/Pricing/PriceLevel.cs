using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class PriceLevel : NameEntity, IOrganizationEntity
    {
        public Guid? OrganizationId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
