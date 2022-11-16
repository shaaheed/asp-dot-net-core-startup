using Msi.Mediator.Abstractions;
using System;

namespace Module.Payments.Domain
{
    public class UpdatePaymentCommand : CreatePaymentCommand, IUpdateCommand<Guid>
    {
        public Guid Id { get; set; }
    }
}
