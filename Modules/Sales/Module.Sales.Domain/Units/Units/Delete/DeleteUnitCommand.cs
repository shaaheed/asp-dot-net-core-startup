using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Units
{
    public class DeleteUnitCommand : IDeleteCommand<Unit, bool>
    {
        public Guid Id { get; set; }
    }
}
