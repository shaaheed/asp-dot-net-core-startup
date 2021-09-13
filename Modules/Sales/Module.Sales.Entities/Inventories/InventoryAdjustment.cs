using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class InventoryAdjustment : OrganizationEntity
    {
        public string Reason { get; set; }
        public DateTimeOffset AdjustmentDate { get; set; }

        public Guid? AccountId { get; set; }
        public virtual Account Account { get; set; }

        public string Description { get; set; }

    }
}
