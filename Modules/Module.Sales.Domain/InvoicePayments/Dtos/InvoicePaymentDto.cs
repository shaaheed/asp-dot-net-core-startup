using Module.Core.Domain;
using Module.Sales.Domain.Invoices;
using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class InvoicePaymentDto
    {
        public long Id { get; set; }
        public long InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public IdNameDto<long> PaymentMethod { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        public string Memo { get; set; }
    }
}
