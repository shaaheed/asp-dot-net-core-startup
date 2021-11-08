using Module.Payments.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Payments.Domain
{
    public class UpdatePaymentCommand : CreatePaymentCommand, IUpdateCommand<Payment, Guid>
    {
        public Guid Id { get; set; }
    }
}
