using System;

namespace Module.Payments.Domain
{
    public class PaymentDto
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public long PaymentMethodId { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        public string Memo { get; set; }
    }
}
