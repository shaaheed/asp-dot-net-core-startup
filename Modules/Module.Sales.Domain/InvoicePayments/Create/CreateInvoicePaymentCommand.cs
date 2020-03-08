using Core.Infrastructure.Commands;
using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class CreateInvoicePaymentCommand : ICommand<long>
    {
        public long InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public long PaymentMethodId { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        public string Memo { get; set; }
    }
}
