using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Units
{
    public class DeleteUnitCommand : IDeleteCommand<bool>
    {
        public Guid Id { get; set; }
    }
}
