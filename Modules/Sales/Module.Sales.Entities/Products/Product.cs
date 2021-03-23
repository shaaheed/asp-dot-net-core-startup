using Module.Systems.Entities;
using System;
using System.Collections.Generic;

namespace Module.Sales.Entities
{
    public class Product : CodeNameEntity
    {
        public string Description { get; set; }

        #region Sales Properties
        public bool IsSale { get; set; }
        public decimal? SalesPrice { get; set; }
        public string SalesDescription { get; set; }
        
        public Guid? SalesUnitId { get; set; }
        public virtual Unit SalesUnit { get; set; }

        public Guid? SalesAccountId { get; set; }
        public virtual ChartOfAccount SalesAccount { get; set; }
        #endregion

        #region Purchase Properties
        public bool IsPurchase { get; set; }
        public decimal? PurchasePrice { get; set; }
        public string PurchaseDescription { get; set; }
        public Guid? PurchaseUnitId { get; set; }
        public virtual Unit PurchaseUnit { get; set; }
        
        public Guid? PurchaseAccountId { get; set; }
        public virtual ChartOfAccount PurchaseAccount { get; set; }

        public Guid? SupplierId { get; set; }
        public virtual Contact Supplier { get; set; }
        #endregion

        #region Inventory Properties
        public bool IsInventory { get; set; }
        public float InitialStockQuantity { get; set; }
        public float StockQuantity { get; set; }
        public float LowStockQuantity { get; set; }
        public Guid? InventoryAccountId { get; set; }
        public virtual ChartOfAccount InventoryAccount { get; set; }
        #endregion

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? SupportStartDate { get; set; }
        public DateTimeOffset? SupportEndDate { get; set; }

        public virtual ICollection<ProductTax> Taxes { get; set; }

    }
}
