using Msi.Mediator.Abstractions;
using System.Collections.Generic;

namespace Module.Payments.Domain
{
    public class GetPaymentsQuery : IQuery<IEnumerable<PaymentDto>>
    {
    }
}
