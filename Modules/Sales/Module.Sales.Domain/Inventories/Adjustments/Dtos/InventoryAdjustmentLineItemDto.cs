using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class InventoryAdjustmentLineItemDto
    {
        public Guid Id { get; set; }
        public GuidIdNameDto Product { get; set; }

        public float QuantityAvailable { get; set; }
        public float NewQuantityOnHand { get; set; }
        public float QuantityAdjusted { get; set; }

        public static Expression<Func<InventoryAdjustmentLineItem, InventoryAdjustmentLineItemDto>> Selector()
        {
            return x => new InventoryAdjustmentLineItemDto
            {
                Id = x.Id,
                NewQuantityOnHand = x.NewQuantityOnHand,
                Product = new GuidIdNameDto { Id = x.ProductId, Name = x.Product.Name },
                QuantityAdjusted = x.QuantityAdjusted,
                QuantityAvailable = x.QuantityAvailable
            };
        }
    }
}
