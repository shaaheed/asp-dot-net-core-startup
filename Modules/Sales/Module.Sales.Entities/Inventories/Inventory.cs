using Msi.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Sales.Entities
{
    public class Inventory : InventoryBase
    {
        public string Memo { get; set; }

        // Enter the rate you want to default to show as the cost for this item when it is returned. What you enter in this field defaults to show in the Override Rate field on item receipts. You can still change this value after it appears on the item receipt.
        [Column(TypeName = "decimal(18,4)")]
        public decimal? DefaultReturnCost { get; set; }

        public float? Value { get; set; }

        // Current quantity available for this item
        // Increased when stock goes into system, decreased when quantity goes out from system
        public float? QuantityOnHand { get; set; }

        // Quantity that is committed to sales order(s) but not yet shipped
        public float? QuantityCommitted { get; set; }

        // Available for Sale = Quantity on Hand - Commited Quantity
        public float? QuantityAvailable { get; set; }

        public float? QuantityOnOrder { get; set; }
        public float? QuantityInTransit { get; set; }
        public float? QuantityBackOrdered { get; set; }
        public float? QuantityCommittedToOrderReservation { get; set; }

    }
}
