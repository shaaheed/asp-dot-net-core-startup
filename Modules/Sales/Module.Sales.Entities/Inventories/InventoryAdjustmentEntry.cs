using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class InventoryAdjustmentEntry : OrganizationEntity
    {
        public Guid? InventoryAdjustmentId { get; set; }
        public virtual InventoryAdjustment InventoryAdjustment { get; set; }

        public Guid? InventoryEntryId { get; set; }
        public virtual InventoryEntry InventoryEntry { get; set; }
    }
}
