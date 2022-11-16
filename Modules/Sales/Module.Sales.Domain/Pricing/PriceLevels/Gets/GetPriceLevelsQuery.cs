using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain
{
    public class GetPriceLevelsQuery : Query<PagedCollection<PriceLevelDto>>
    {
    }
}
