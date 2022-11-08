using Msi.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Sales.Entities
{
    public class Stock : OrganizationEntity
    {
        public string Memo { get; set; }

        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        // Stock Unit
        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        public Guid? BaseUnitId { get; set; }
        public virtual Unit BaseUnit { get; set; }

        // Serial/Lot/Batch Number
        public string StockNumber { get; set; }

        public DateTimeOffset? ExpirationDate { get; set; }
        public DateTimeOffset? ManufacturingDate { get; set; }

        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }

        // Enter the rate you want to default to show as the cost for this item when it is returned. What you enter in this field defaults to show in the Override Rate field on item receipts. You can still change this value after it appears on the item receipt.
        [Column(TypeName = "decimal(18,4)")]
        public decimal? DefaultReturnCost { get; set; }

        public float? QuantityOnHand { get; set; } // readonly
        public float? Value { get; set; } // readonly
        public float? QuantityCommitted { get; set; } // readonly
        public float? QuantityAvailable { get; set; } // readonly
        public float? QuantityOnOrder { get; set; } // readonly
        public float? QuantityInTransit { get; set; } // readonly
        public float? QuantityBackOrdered { get; set; } // readonly
        public float? QuantityCommittedToOrderReservation { get; set; } // readonly

    }
}
