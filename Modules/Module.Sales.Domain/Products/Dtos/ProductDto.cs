using Module.Core.Domain;
using System;

namespace Module.Sales.Domain.Products
{
    public class ProductDto 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public IdNameDto<long> Category { get; set; }
        public IdNameDto<long> Manufacturer { get; set; }
        public IdNameDto<long> UnitOfMeasurement { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsSale { get; set; }
        public bool IsBuy { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? SupportStartDate { get; set; }
        public DateTimeOffset? SupportEndDate { get; set; }
    }
}
