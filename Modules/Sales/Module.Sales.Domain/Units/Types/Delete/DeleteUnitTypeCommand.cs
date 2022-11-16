using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Units
{
    public class DeleteUnitTypeCommand : IDeleteCommand<bool>
    {
        public Guid Id { get; set; }
    }
}
