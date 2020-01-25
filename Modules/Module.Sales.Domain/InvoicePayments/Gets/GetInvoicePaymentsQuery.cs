using Core.Infrastructure.Queries;
using System.Collections.Generic;

namespace Module.Sales.Domain.InvoicePayments
{
    public class GetInvoicePaymentsQuery : IQuery<IEnumerable<InvoicePaymentDto>>
    {
    }
}
