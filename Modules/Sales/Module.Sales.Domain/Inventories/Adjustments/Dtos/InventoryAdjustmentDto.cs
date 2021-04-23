using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class InventoryAdjustmentDto
    {
        public Guid Id { get; set; }
        public string Reference { get; set; }
        public string Reason { get; set; }
        public DateTimeOffset? AdjustmentDate { get; set; }

        public GuidCodeNameDto Account { get; set; }
        public string Description { get; set; }
        public List<InventoryAdjustmentLineItemDto> LineItems { get; set; }

        public static Expression<Func<InventoryAdjustment, InventoryAdjustmentDto>> Selector()
        {
            return x => new InventoryAdjustmentDto
            {
                Id = x.Id,
                Account = x.AccountId != null ? new GuidCodeNameDto { } : null,
                AdjustmentDate = x.AdjustmentDate,
                Description = x.Description,
                Reason = x.Reason,
                Reference = x.Reference
            };
        }
    }
}
