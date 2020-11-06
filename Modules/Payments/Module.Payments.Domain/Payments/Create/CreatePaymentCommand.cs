using Msi.Mediator.Abstractions;
using System;

namespace Module.Payments.Domain
{
    public class CreatePaymentCommand : ICommand<long>
    {
        public long? CustomerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
    }
}
