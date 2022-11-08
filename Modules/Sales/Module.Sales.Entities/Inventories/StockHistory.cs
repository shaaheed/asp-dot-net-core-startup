using Msi.Data.Entity;

namespace Module.Sales.Entities
{
    public class StockHistory : OrganizationEntity
    {
        public string Note { get; set; }

        public Guid? StockId { get; set; }
        public virtual Stock Stock { get; set; }

        // Sale/Purchase/Adjustment Unit
        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        public float Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
