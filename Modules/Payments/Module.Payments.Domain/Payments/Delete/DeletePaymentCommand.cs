using Msi.Mediator.Abstractions;
using System;

namespace Module.Payments.Domain
{
    public class DeletePaymentCommand : ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
