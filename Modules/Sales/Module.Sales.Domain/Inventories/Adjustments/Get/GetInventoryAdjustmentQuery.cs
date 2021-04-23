using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class GetInventoryAdjustmentQuery : IQuery<InventoryAdjustmentDto>
    {
        public Guid Id { get; set; }
    }
}
