using Msi.Mediator.Abstractions;
using System;

namespace Module.Payments.Domain
{
    public class GetPaymentQuery : IQuery<PaymentDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
