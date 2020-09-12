using Core.Interfaces.Entities;
using System;

namespace Module.Sales.Entities
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }
        public string Code { get; set; }

        public long? CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        public long? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public long? UnitOfMeasurementId { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }

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

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? SupportStartDate { get; set; }
        public DateTimeOffset? SupportEndDate { get; set; }

    }
}
