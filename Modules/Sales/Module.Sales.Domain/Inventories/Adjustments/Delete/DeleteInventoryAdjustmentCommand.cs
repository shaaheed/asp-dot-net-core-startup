using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class DeleteInventoryAdjustmentCommand : ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
