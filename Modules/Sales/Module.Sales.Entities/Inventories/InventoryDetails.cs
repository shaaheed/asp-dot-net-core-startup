using Msi.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Sales.Entities
{
    public class InventoryDetails : OrganizationEntity
    {
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        // Should be store as Location wise
        //// The stock available for sale at the beginning of the accounting period
        //public float InitialStockQuantity { get; set; }

        //// The rate which you bought each unit of the opening stock
        //public float? InitialStockRate { get; set; }

        // Base unit
        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        // Sum of all locations quantity
        public float StockQuantity { get; set; }

        public float LowStockQuantity { get; set; }

        //public DateTimeOffset? AsOfDate { get; set; }

        // When yout stock reaches the reorder point, a notification will be sent to you
        public float? ReorderPoint { get; set; }

        public Guid? AccountId { get; set; }
        public virtual Account Account { get; set; }

        // Default location where to stock
        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }

        // Continue selling when out of stock
        public bool IsSellOutOfStock { get; set; }
    }
}
