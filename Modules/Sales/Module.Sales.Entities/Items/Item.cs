using Module.Systems.Entities;

namespace Module.Sales.Entities
{
    public class Item : OrganizationCodeNameEntity
    {
        // Barcode should be unique across the system
        public string Barcode { get; set; }
        public string Description { get; set; }

        public ItemType Type { get; set; }
        public ItemSubType? SubType { get; set; }

        public Guid? ParentId { get; set; }
        public virtual Item Parent { get; set; }

        // once created, then readonly
        public Guid? UnitTypeId { get; set; }
        public UnitType UnitType { get; set; }

        public Guid? SaleDetailsId { get; set; }
        public virtual SaleDetails SaleDetails { get; set; }

        public Guid? PurchaseDetailsId { get; set; }
        public virtual PurchaseDetails PurchaseDetails { get; set; }

        public Guid? InventoryDetailsId { get; set; }
        public virtual InventoryDetails InventoryDetails { get; set; }

        public Guid? ShippingDetailsId { get; set; }
        public virtual ShippingDetails ShippingDetails { get; set; }

        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? SupportStartDate { get; set; }
        public DateTimeOffset? SupportEndDate { get; set; }

        // Minimum Order Quantity
        public float? MinOrderQty { get; set; }
        // Maximum Order Quantity
        public float? MaxOrderQty { get; set; }

    }
}
