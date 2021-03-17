using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Taxes
{
    public class GetTaxesQuery : Query<PagedCollection<TaxListItemDto>>
    {
    }
}
