using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain
{
    public class GetVariantsQuery : Query<PagedCollection<VariantListItemDto>>
    {
    }
}
