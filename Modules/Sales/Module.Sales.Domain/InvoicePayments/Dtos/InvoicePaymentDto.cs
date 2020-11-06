using Module.Core.Domain;
using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class InvoicePaymentDto
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public IdNameDto<Guid> PaymentMethod { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        public string Memo { get; set; }
    }
}
