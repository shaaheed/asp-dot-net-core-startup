using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class GetPriceLevelQuery : IQuery<PriceLevelDto>
    {
        public Guid Id { get; set; }
    }
}
