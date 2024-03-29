﻿using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain
{
    public class CreateInventoryAdjustmentCommand : ICommand<long>
    {
        public string Reason { get; set; }
        public DateTimeOffset AdjustmentDate { get; set; }

        public Guid? AccountId { get; set; }
        public string Description { get; set; }
        public List<InventoryAdjustmentLineItemRequestDto> LineItems { get; set; }

        public virtual InventoryAdjustment Map(InventoryAdjustment entity = null)
        {
            entity = entity ?? new InventoryAdjustment();
            entity.Reason = Reason;
            entity.Date = AdjustmentDate;
            entity.AccountId = AccountId;
            entity.Description = Description;
            return entity;
        }
    }
}
