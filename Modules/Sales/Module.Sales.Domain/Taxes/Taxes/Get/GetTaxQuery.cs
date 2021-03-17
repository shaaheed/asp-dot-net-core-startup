using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Taxes
{
    public class GetTaxQuery : IQuery<TaxDto>
    {
        public Guid Id { get; set; }
    }
}
