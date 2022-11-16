using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class InventoryAdjustment : OrganizationEntity
    {
        public InventoryEntryType Type { get; set; }
        public string Reason { get; set; }
        public DateTimeOffset Date { get; set; }

        public Guid? AccountId { get; set; }
        public virtual Account Account { get; set; }

        public string Description { get; set; }

        // Enter an optional memo for this adjustment. It will appear on a register or Account Detail report.
        public string Memo { get; set; }

    }
}
