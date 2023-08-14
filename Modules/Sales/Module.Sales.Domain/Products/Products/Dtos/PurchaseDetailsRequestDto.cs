using Module.Sales.Entities;
using System;

namespace Module.Sales.Domain.Products
{
    public class PurchaseDetailsRequestDto : ItemDetailsRequestDto
    {
        public decimal? AverageCost { get; set; }
        public decimal? LastPurchasePrice { get; set; }
        public decimal? TotalValue { get; set; }
        public Guid? SupplierId { get; set; }
        public Guid? LocationId { get; set; }

        public virtual PurchaseDetails Map(PurchaseDetails entity = null)
        {
            entity = base.Map(entity ?? new PurchaseDetails()) as PurchaseDetails;
            entity.AverageCost = AverageCost;
            entity.LastPurchasePrice = LastPurchasePrice;
            entity.TotalValue = TotalValue;
            entity.SupplierId = SupplierId;
            entity.LocationId = LocationId;
            return entity;
        }
    }
}
