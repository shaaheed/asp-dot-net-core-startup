using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class InventoryAdjustment : OrganizationBaseEntity
    {
        // can be use as reason
        public string Reference { get; set; }
        public DateTimeOffset? AdjustmentDate { get; set; }

        public Guid? AccountId { get; set; }
        public virtual ChartOfAccount Account { get; set; }

        public string Description { get; set; }

    }
}
