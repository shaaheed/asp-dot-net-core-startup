using Module.Systems.Entities;
using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    [IgnoredEntity]
    public class InventoryBase : OrganizationEntity
    {
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        // Serial/Lot/Batch Number
        public string StockNumber { get; set; }

        // Sale/Purchase/Adjustment Unit
        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }

        public Guid? ItemVariantOptionId { get; set; }
        public ItemVariantOption ItemVariantOption { get; set; }

        public Guid? AccountId { get; set; }
        public virtual Account Account { get; set; }

        public DateTimeOffset? ExpirationDate { get; set; }
        public DateTimeOffset? ManufacturingDate { get; set; }

    }
}
