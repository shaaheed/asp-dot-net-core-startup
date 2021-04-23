using System;

namespace Module.Sales.Domain
{
    public class UpdateInventoryAdjustmentCommand : CreateInventoryAdjustmentCommand
    {
        public Guid Id { get; set; }
    }
}
