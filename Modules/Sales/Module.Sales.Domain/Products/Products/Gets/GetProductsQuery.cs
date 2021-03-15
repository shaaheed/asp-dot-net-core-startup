using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Products
{
    public class GetProductsQuery : Query<PagedCollection<ProductListItemDto>>
    {
    }
}
