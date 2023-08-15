using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Items
{
    public class UpdateItemCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? UnitTypeId { get; set; }
        public Guid? GroupId { get; set; }

        public List<Guid> Categories { get; set; }

        #region Sales Properties
        public bool IsSale { get; set; }
        public ItemSaleDetailsRequestDto SaleDetails { get; set; }
        #endregion

        #region Purchase Properties
        public bool IsPurchase { get; set; }
        public ItemPurchaseDetailsRequestDto PurchaseDetails { get; set; }
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

        public float? MinOrderQty { get; set; }
        public float? MaxOrderQty { get; set; }

        public virtual Item Map(Item entity = null)
        {
            entity = entity ?? new Item();
            entity.Barcode = Barcode;
            entity.Name = Name;
            entity.Code = Code;
            entity.Description = Description;
            entity.UnitTypeId = UnitTypeId;
            entity.GroupId = GroupId;
            entity.IsSale = IsSale;
            entity.IsPurchase = IsPurchase;

            entity.IsInventory = IsInventory;
            /*entity.InitialStockQuantity = InitialStockQuantity;
            entity.StockQuantity = StockQuantity;
            entity.LowStockQuantity = LowStockQuantity;
            entity.InventoryAccountId = InventoryAccountId;
            entity.SupplierId = SupplierId;*/

            entity.StartDate = StartDate;
            entity.EndDate = EndDate;
            entity.SupportStartDate = SupportStartDate;
            entity.SupportEndDate = SupportEndDate;

            entity.MaxOrderQty = MaxOrderQty;
            entity.MinOrderQty = MinOrderQty;
            return entity;
        }
    }
}
