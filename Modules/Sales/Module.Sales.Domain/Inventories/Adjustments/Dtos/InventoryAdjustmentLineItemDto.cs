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

        public static Expression<Func<LineItem, InventoryAdjustmentLineItemDto>> Selector()
        {
            return x => new InventoryAdjustmentLineItemDto
            {
                Id = x.Id,
                NewQuantityOnHand = x.Product.StockQuantity,
                Product = new GuidIdNameDto { Id = x.Product.Id, Name = x.Product.Name },
                QuantityAdjusted = x.Quantity,
                QuantityAvailable = x.Product.StockQuantity
            };
        }
    }
}
