using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class CreateInvoicePaymentCommand : ICommand<long>
    {
        public Guid InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public Guid PaymentMethodId { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        public string Memo { get; set; }
    }
}
