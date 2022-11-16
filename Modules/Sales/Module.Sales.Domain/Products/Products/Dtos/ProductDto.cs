using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Module.Sales.Domain.Products
{
    public class ProductDto : GuidCodeNameDto
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public IEnumerable<GuidIdNameDto> Categories { get; set; }

        // Sales Properties
        public bool IsSale { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? MRP { get; set; }
        public string SalesDescription { get; set; }
        public GuidIdNameDto SalesUnit { get; set; }
        public GuidCodeNameDto SalesAccount { get; set; }
        public ICollection<GuidCodeNameDto> SalesTaxes { get; set; }

        // Purchase Properties
        public bool IsPurchase { get; set; }
        public decimal? PurchasePrice { get; set; }
        public string PurchaseDescription { get; set; }
        public GuidIdNameDto PurchaseUnit { get; set; }
        public GuidCodeNameDto PurchaseAccount { get; set; }
        public ICollection<GuidCodeNameDto> PurchaseTaxes { get; set; }
        public GuidIdNameDto Supplier { get; set; }

        // Inventory Properties
        public bool IsInventory { get; set; }
        public float InitialStockQuantity { get; set; }
        public float StockQuantity { get; set; }
        public float LowStockQuantity { get; set; }
        public GuidCodeNameDto InventoryAccount { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? SupportStartDate { get; set; }
        public DateTimeOffset? SupportEndDate { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public float? MinOrderQty;
        public float? MaxOrderQty;

        public static Expression<Func<Item, ProductDto>> Selector()
        {
            return x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Barcode = x.Barcode,
                Description = x.Description,

                IsSale = x.IsSale,
                /*SalesPrice = x.SalesPrice,
                MRP = x.MRP,
                SalesDescription = x.SalesDescription,
                SalesUnit = x.SalesUnit != null ? new GuidIdNameDto
                {
                    Id = (Guid)x.SalesUnitId,
                    Name = x.SalesUnit.Name,
                } : null,
                SalesAccount = x.SalesAccount != null ? new GuidCodeNameDto
                {
                    Id = (Guid)x.SalesAccountId,
                    Name = x.SalesAccount.Name,
                    Code = x.SalesAccount.Code
                } : null,*/

                IsPurchase = x.IsPurchase,
                /*PurchasePrice = x.PurchasePrice,
                PurchaseDescription = x.PurchaseDescription,
                PurchaseUnit = x.PurchaseUnit != null ? new GuidIdNameDto
                {
                    Id = (Guid)x.PurchaseUnitId,
                    Name = x.PurchaseUnit.Name,
                } : null,
                PurchaseAccount = x.PurchaseAccount != null ? new GuidCodeNameDto
                {
                    Id = (Guid)x.PurchaseAccountId,
                    Name = x.PurchaseAccount.Name,
                    Code = x.PurchaseAccount.Code
                } : null,
                Supplier = x.SupplierId != null ? new GuidIdNameDto
                {
                    Id = (Guid)x.SupplierId,
                    Name = x.Supplier.DisplayName
                } : null,*/

                IsInventory = x.IsInventory,
                /*InitialStockQuantity = x.InitialStockQuantity,
                StockQuantity = x.StockQuantity,
                LowStockQuantity = x.LowStockQuantity,
                InventoryAccount = x.InventoryAccount != null ? new GuidCodeNameDto
                {
                    Id = (Guid)x.InventoryAccountId,
                    Name = x.InventoryAccount.Name,
                    Code = x.InventoryAccount.Code
                } : null,*/

                StartDate = x.StartDate,
                EndDate = x.EndDate,
                SupportStartDate = x.SupportStartDate,
                SupportEndDate = x.SupportEndDate,
                MinOrderQty = x.MinOrderQty,
                MaxOrderQty = x.MaxOrderQty,

                CreatedAt = x.CreatedAt
            };
        }
    }
}
