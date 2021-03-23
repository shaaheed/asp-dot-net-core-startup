using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Products
{
    public class UpdateProductCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Guid> Categories { get; set; }

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
        public float InitialStockQuantity { get; set; }
        public float StockQuantity { get; set; }
        public float LowStockQuantity { get; set; }
        public Guid? InventoryAccountId { get; set; }
        #endregion

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? SupportStartDate { get; set; }
        public DateTimeOffset? SupportEndDate { get; set; }

        public virtual Product Map(Product entity = null)
        {
            entity = entity ?? new Product();
            entity.Name = Name;
            entity.Code = Code;
            entity.Description = Description;

            entity.IsSale = IsSale;
            entity.SalesPrice = SalesPrice;
            entity.SalesDescription = SalesDescription;
            entity.SalesUnitId = SalesUnitId;
            entity.SalesAccountId = SalesAccountId;

            entity.IsPurchase = IsPurchase;
            entity.PurchasePrice = PurchasePrice;
            entity.PurchaseDescription = PurchaseDescription;
            entity.PurchaseUnitId = PurchaseUnitId;
            entity.PurchaseAccountId = PurchaseAccountId;

            entity.IsInventory = IsInventory;
            entity.InitialStockQuantity = InitialStockQuantity;
            entity.StockQuantity = StockQuantity;
            entity.LowStockQuantity = LowStockQuantity;
            entity.InventoryAccountId = InventoryAccountId;
            entity.SupplierId = SupplierId;

            entity.StartDate = StartDate;
            entity.EndDate = EndDate;
            entity.SupportStartDate = SupportStartDate;
            entity.SupportEndDate = SupportEndDate;
            return entity;
        }
    }
}
