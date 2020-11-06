using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System;

namespace Module.Sales.Domain.Products
{
    public class CreateProductCommand : CommandBase<long>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsSale { get; set; }
        public bool IsBuy { get; set; }

        public Guid? CategoryId { get; set; }
        public Guid? ManufacturerId { get; set; }
        public Guid? UnitOfMeasurementId { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? SupportStartDate { get; set; }
        public DateTimeOffset? SupportEndDate { get; set; }

        public static Product To(CreateProductCommand command)
        {
            var newProduct = new Product
            {
                Name = command.Name,
                Code = command.Code,
                CategoryId = command.CategoryId,
                ManufacturerId = command.ManufacturerId,
                UnitOfMeasurementId = command.UnitOfMeasurementId,
                Description = command.Description,
                Price = command.Price,
                IsBuy = command.IsBuy,
                IsSale = command.IsSale,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                SupportStartDate = command.SupportStartDate,
                SupportEndDate = command.SupportEndDate
            };
            var newEvent = new ProductCreatedEvent();
            newEvent.GenerateType();
            //newProduct.Append(newEvent);
            return newProduct;
        }

        public static ProductDto To(Product product)
        {
            var dto = new ProductDto
            {
                Name = product.Name,
                Code = product.Code,
                Description = product.Description,
                Price = product.Price,
                IsBuy = product.IsBuy,
                IsSale = product.IsSale,
            };
            return dto;
        }
    }
}
