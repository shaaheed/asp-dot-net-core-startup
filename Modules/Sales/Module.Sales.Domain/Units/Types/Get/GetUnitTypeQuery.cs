using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Units
{
    public class GetUnitTypeQuery : IQuery<UnitTypeDto>
    {
        public Guid Id { get; set; }
    }
}
