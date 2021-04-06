using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class GetInvoicePaymentQuery : IQuery<InvoicePaymentDto>
    {
        public Guid InvoiceId { get; set; }
        public Guid Id { get; set; }
    }
}
