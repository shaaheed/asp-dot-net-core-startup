using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class UpdateUnitTypeCommand : CreateUnitTypeCommand
    {
        public Guid Id { get; set; }
    }
}
