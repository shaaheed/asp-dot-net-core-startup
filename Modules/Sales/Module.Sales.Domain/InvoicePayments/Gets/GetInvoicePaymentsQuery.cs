using Msi.Mediator.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.InvoicePayments
{
    public class GetInvoicePaymentsQuery : IQuery<IEnumerable<InvoicePaymentDto>>
    {
        public Guid InvoiceId { get; set; }
    }
}
