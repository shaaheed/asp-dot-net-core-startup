using Core.Interfaces.Entities;

namespace Module.Sales.Entities
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsCallForPricing { get; set; }
        public int StockQuantity { get; set; }
        public bool IsSale { get; set; }
        public bool IsBuy { get; set; }
        public bool IsInventory { get; set; }

    }
}
