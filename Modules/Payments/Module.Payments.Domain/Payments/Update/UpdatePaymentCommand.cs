using Msi.Mediator.Abstractions;
using System;

namespace Module.Payments.Domain
{
    public class UpdatePaymentCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
    }
}
