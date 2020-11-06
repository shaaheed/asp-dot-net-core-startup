using Msi.Mediator.Abstractions;
using System.Collections.Generic;

namespace Module.Sales.Domain.Invoices
{
    public class GetInvoicesQuery : IQuery<IEnumerable<InvoiceDto>>
    {
    }
}
