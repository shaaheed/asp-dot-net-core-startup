using Module.Sales.Entities;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Items
{
    public class ItemSaleDetailsRequestDto : ItemDetailsRequestDto
    {
        public decimal? AveragePrice { get; set; }
        public decimal? MRP { get; set; }
        public List<Guid> Currencies { get; set; }

        public virtual ItemSaleDetails Map(ItemSaleDetails entity = null)
        {
            entity = base.Map(entity ?? new ItemSaleDetails()) as ItemSaleDetails;
            entity.AveragePrice = AveragePrice;
            entity.MRP = MRP;
            return entity;
        }
    }
}
