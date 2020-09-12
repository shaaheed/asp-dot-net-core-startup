using Core.Infrastructure.Commands;
using System;

namespace Module.Sales.Domain.Products
{
    public class UpdateProductCommand : ICommand<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsSale { get; set; }
        public bool IsBuy { get; set; }

        public long? CategoryId { get; set; }
        public long? ManufacturerId { get; set; }
        public long? UnitOfMeasurementId { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? SupportStartDate { get; set; }
        public DateTimeOffset? SupportEndDate { get; set; }
    }
}
