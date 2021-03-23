using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Invoices
{
    public class GetInvoicesQuery : Query<PagedCollection<InvoiceListItemDto>>
    {
    }
}
