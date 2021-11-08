using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Products
{
    public class GetProductTransactionsQuery : Query<PagedCollection<ProductTransactionListItemDto>>
    {
    }
}
