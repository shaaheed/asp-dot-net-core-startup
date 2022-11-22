using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class GetVariantQuery : IQuery<VariantDto>
    {
        public Guid Id { get; set; }
    }
}
