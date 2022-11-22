using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;
using System;

namespace Module.Sales.Domain
{
    public class GetVariantOptionsQuery : Query<PagedCollection<VariantOptionDto>>
    {
        public Guid VariantId { get; set; }
    }
}
