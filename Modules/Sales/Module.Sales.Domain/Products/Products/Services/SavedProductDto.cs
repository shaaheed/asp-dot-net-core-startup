using System;

namespace Module.Sales.Domain
{
    public class SavedProductDto
    {
        public Guid Id { get; set; }
        public float StockQuantity { get; set; }
        public string Name { get; set; }
        public bool IsInventory { get; set; }
        public bool IsSale { get; set; }
        public bool IsDeleted { get; set; }
    }
}
