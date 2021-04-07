using Msi.Mediator.Abstractions;
using System;

namespace Module.Payments.Domain
{
    public class CreatePaymentCommand : ICommand<long>
    {
        public string Number { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
    }
}
