using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using Msi.Domain.Abstractions;

namespace Module.Sales.Domain.Items
{
    public class ItemDto : GuidCodeNameDto
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public IEnumerable<GuidIdNameDto> Categories { get; set; }
        public IdNameDto UnitType { get; set; }
        public IdNameDto Group { get; set; }

        // Sales Properties
        public bool IsSale { get; set; }
        public ItemSaleDetailsDto SaleDetails { get; set; }

        // Purchase Properties
        public bool IsPurchase { get; set; }
        public ItemPurchaseDetailsDto PurchaseDetails { get; set; }

        // Inventory Properties
        public bool IsInventory { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? SupportStartDate { get; set; }
        public DateTimeOffset? SupportEndDate { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public float? MinOrderQty;
        public float? MaxOrderQty;

        public static Expression<Func<Item, ItemDto>> Selector()
        {
            return x => new ItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Barcode = x.Barcode,
                Description = x.Description,
                UnitType = x.UnitTypeId != null ? new IdNameDto
                {
                    Id = x.UnitType.Id,
                    Name = x.UnitType.Name
                } : null,
                Group = x.GroupId != null ? new IdNameDto
                {
                    Id = x.Group.Id,
                    Name = x.Group.Name
                } : null,
                IsSale = x.IsSale,
                IsPurchase = x.IsPurchase,
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
