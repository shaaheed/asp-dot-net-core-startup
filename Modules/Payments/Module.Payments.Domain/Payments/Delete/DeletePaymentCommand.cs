using Module.Payments.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Payments.Domain
{
    public class DeletePaymentCommand : IDeleteCommand<Payment, bool>
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
    }
}
