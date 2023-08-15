using Module.Sales.Entities;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Items
{
    public class ItemPurchaseDetailsRequestDto : ItemDetailsRequestDto
    {
        public decimal? AverageCost { get; set; }
        public decimal? LastPurchasePrice { get; set; }
        public decimal? TotalValue { get; set; }
        public Guid? SupplierId { get; set; }
        public Guid? LocationId { get; set; }
        public List<Guid> Currencies { get; set; }

        public virtual ItemPurchaseDetails Map(ItemPurchaseDetails entity = null)
        {
            entity = base.Map(entity ?? new ItemPurchaseDetails()) as ItemPurchaseDetails;
            entity.AverageCost = AverageCost;
            entity.LastPurchasePrice = LastPurchasePrice;
            entity.TotalValue = TotalValue;
            entity.SupplierId = SupplierId;
            entity.LocationId = LocationId;
            return entity;
        }
    }
}
