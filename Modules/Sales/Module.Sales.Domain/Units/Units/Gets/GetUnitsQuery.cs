using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Products
{
    public class GetUnitsQuery : Query<PagedCollection<UnitListItemDto>>
    {
    }
}
