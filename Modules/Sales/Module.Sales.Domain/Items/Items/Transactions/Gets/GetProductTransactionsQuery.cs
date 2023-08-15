using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Items
{
    public class GetProductTransactionsQuery : Query<PagedCollection<ItemTransactionListItemDto>>
    {
    }
}
