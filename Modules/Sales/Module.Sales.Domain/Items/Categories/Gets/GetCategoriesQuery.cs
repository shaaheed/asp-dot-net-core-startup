using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Items
{
    public class GetCategoriesQuery : Query<PagedCollection<CategoryListItemDto>>
    {
    }
}
