using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Products
{
    public class GetUnitQuery : IQuery<UnitDto>
    {
        public Guid Id { get; set; }
    }
}
