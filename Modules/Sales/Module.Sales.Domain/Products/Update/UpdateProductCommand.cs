using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Products
{
    public class UpdateProductCommand : ICommand<long>
    {
        public Guid Id { get; set; }
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
    }
}
