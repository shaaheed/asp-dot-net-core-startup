using Module.Sales.Entities;
using System;

namespace Module.Sales.Domain
{
    public class InventoryAdjustmentLineItemRequestDto
    {
        public Guid? Id { get; set; }
        public Guid ProductId { get; set; }
        public float Quantity { get; set; }

        public virtual InventoryAdjustmentLineItem Map(Guid adjustmentId, InventoryAdjustmentLineItem entity = null)
        {
            entity = entity ?? new InventoryAdjustmentLineItem();
            entity.ProductId = ProductId;
            entity.InventoryAdjustmentId = adjustmentId;
            entity.QuantityAdjusted = Quantity;
            return entity;
        }
    }
}
