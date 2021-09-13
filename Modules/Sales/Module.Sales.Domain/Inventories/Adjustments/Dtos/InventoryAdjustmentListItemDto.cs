using Module.Sales.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class InventoryAdjustmentListItemDto
    {
        public Guid Id { get; set; }
        public string Reference { get; set; }
        public string Reason { get; set; }
        public DateTimeOffset? AdjustmentDate { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<InventoryAdjustment, InventoryAdjustmentListItemDto>> Selector()
        {
            return x => new InventoryAdjustmentListItemDto
            {
                Id = x.Id,
                AdjustmentDate = x.AdjustmentDate,
                Reason = x.Reason,
                //Status = x.Type.ToString(),
                CreatedAt = x.CreatedAt
            };
        }
    }
}
