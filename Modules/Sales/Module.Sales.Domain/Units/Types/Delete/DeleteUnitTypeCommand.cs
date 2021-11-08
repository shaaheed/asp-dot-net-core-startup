using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Units
{
    public class DeleteUnitTypeCommand : IDeleteCommand<UnitType, bool>
    {
        public Guid Id { get; set; }
    }
}
