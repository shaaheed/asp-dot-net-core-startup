using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Units
{
    public class DeleteUnitCommand : CommandBase<long>
    {
        public Guid Id { get; set; }
    }
}
