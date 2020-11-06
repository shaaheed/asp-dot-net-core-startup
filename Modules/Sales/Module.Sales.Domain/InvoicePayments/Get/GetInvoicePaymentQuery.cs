using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class GetInvoicePaymentQuery : IQuery<InvoicePaymentDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
