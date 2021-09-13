﻿using Module.Sales.Entities;
using System;

namespace Module.Sales.Domain
{
    public class InventoryAdjustmentLineItemRequestDto
    {
        public Guid? Id { get; set; }
        public Guid ProductId { get; set; }
        public float Quantity { get; set; }

        public virtual LineItem Map(Guid adjustmentId, LineItem entity = null)
        {
            entity = entity ?? new LineItem();
            entity.ProductId = ProductId;
            entity.ReferenceId = adjustmentId;
            entity.Quantity = Quantity;
            entity.Type = ItemTransactionType.Adjustment;
            return entity;
        }
    }
}
