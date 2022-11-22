using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class GetVariantOptionQuery : IQuery<VariantOptionDto>
    {
        public Guid Id { get; set; }
    }
}
