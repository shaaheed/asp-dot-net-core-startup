using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System;

namespace Module.Sales.Domain.Products
{
    public class CreateProductCommand : CommandBase<long>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #region Sales Properties
        public bool IsSale { get; set; }
        public decimal? SalesPrice { get; set; }
        public string SalesDescription { get; set; }
        public Guid? SalesUnitId { get; set; }
        public Guid? SalesAccountId { get; set; }
        #endregion

        #region Purchase Properties
        public bool IsPurchase { get; set; }
        public decimal? PurchasePrice { get; set; }
        public string PurchaseDescription { get; set; }
        public Guid? PurchaseUnitId { get; set; }
        public Guid? PurchaseAccountId { get; set; }
        public Guid? SupplierId { get; set; }
        #endregion

        #region Inventory Properties
        public bool IsInventory { get; set; }
        public int StockQuantity { get; set; }
        public int LowStockQuantity { get; set; }
        public Guid? InventoryAccountId { get; set; }
        #endregion

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
                Description = command.Description,

                IsSale = command.IsSale,
                SalesPrice = command.SalesPrice,
                SalesDescription = command.SalesDescription,
                SalesUnitId = command.SalesUnitId,
                SalesAccountId = command.SalesAccountId,

                IsPurchase = command.IsPurchase,
                PurchasePrice = command.PurchasePrice,
                PurchaseDescription = command.PurchaseDescription,
                PurchaseUnitId = command.PurchaseUnitId,
                PurchaseAccountId = command.PurchaseAccountId,

                IsInventory = command.IsInventory,
                StockQuantity = command.StockQuantity,
                LowStockQuantity = command.LowStockQuantity,
                InventoryAccountId = command.InventoryAccountId,
                SupplierId = command.SupplierId,

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
                //Price = product.Price,
                //IsBuy = product.IsBuy,
                IsSale = product.IsSale,
            };
            return dto;
        }
    }
}
