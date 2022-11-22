using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain
{
    public class GetUnitsQuery : Query<PagedCollection<UnitListItemDto>>
    {
    }
}
