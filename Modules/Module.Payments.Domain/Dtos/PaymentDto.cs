using System;

namespace Module.Payments.Domain
{
    public class PaymentDto
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
    }
}
