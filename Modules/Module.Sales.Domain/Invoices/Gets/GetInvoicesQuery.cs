using Core.Infrastructure.Queries;
using System.Collections.Generic;

namespace Module.Sales.Domain.Invoices
{
    public class GetInvoicesQuery : IQuery<IEnumerable<InvoiceDto>>
    {
    }
}
