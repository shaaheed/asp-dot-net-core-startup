using Module.Systems.Domain;
using System;

namespace Module.Sales.Domain
{
    public class BaseInvoicePaymentDto
    {
        public string Number { get; set; }
        public Guid Id { get; set; }
        public Guid PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public DateTimeOffset PaymentDate { get; set; }

        public Guid? PaymentAccountId { get; set; }
        public Guid? CustomerId { get; set; }

        public string Memo { get; set; }
        public GuidIdNameDto PaymentMethod { get; set; }
    }
}
