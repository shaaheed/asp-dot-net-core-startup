using Module.Systems.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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


        // Sale
        public bool IsSale { get; set; }
        // Enable this option if the item is eligible for sales return
        public bool IsReturnable { get; set; }
        public Guid? SaleDetailsId { get; set; }
        [ForeignKey(nameof(SaleDetailsId))]
        public virtual SaleDetails SaleDetails { get; set; }

        // Purchase
        public bool IsPurchase { get; set; }
        public Guid? PurchaseDetailsId { get; set; }
        [ForeignKey(nameof(PurchaseDetailsId))]
        public virtual PurchaseDetails PurchaseDetails { get; set; }

        // Inventory
        public bool IsInventory { get; set; }
        public Guid? InventoryDetailsId { get; set; }
        [ForeignKey(nameof(InventoryDetailsId))]
        public virtual InventoryDetails InventoryDetails { get; set; }

        // Shipping
        public bool IsShip { get; set; }
        public Guid? ShippingDetailsId { get; set; }
        public virtual ShippingDetails ShippingDetails { get; set; }

        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }

        // Total number location
        public int? LocationCount { get; set; } // readonly
        // Total count of variation used for this item
        public int? VariationCount { get; set; } // readonly

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? SupportStartDate { get; set; }
        public DateTimeOffset? SupportEndDate { get; set; }

        // Minimum Order Quantity
        // Enter the lowest quantity that customers can purchase.  Web store customers receive a warning and cannot check out if they enter an item quantity below this minimum. 
        // Leave this field empty to allow customers to check out with no minimum quantity restrictions.
        public float? MinOrderQty { get; set; }

        // Maximum Order Quantity
        // Enter the greatest quantity of this item that customers can purchase. If customers enter an item quantity above the maximum amount, a warning message is displayed. Web store customers are unable to complete checkout unless they enter a quantity equal to or below the maximum quantity.
        // Leave this field empty to allow customers to check out without maximum quantity restrictions.
        public float? MaxOrderQty { get; set; }

    }
}
