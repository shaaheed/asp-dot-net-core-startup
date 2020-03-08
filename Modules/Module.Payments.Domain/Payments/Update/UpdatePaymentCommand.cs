using Core.Infrastructure.Commands;
using System;

namespace Module.Payments.Domain
{
    public class UpdatePaymentCommand : ICommand<long>
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
    }
}
