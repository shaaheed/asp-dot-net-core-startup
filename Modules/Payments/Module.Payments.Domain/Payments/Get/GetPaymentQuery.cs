﻿using Msi.Mediator.Abstractions;
using System;

namespace Module.Payments.Domain
{
    public class GetPaymentQuery : ISingleQuery<PaymentDetailsDto>
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
    }
}
