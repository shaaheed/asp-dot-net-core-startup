using Msi.Data.Entity;

namespace Module.Sales.Entities
{
    public class InventoryDetails : OrganizationEntity
    {
        public float InitialStockQuantity { get; set; }
        public float StockQuantity { get; set; }
        public float LowStockQuantity { get; set; }

        public DateTimeOffset? AsOfDate { get; set; }

        public Guid? AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
