using System;

namespace Module.Payments.Domain
{
    public class PaymentDetailsDto
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset PaymentDueDate { get; set; }
    }
}
