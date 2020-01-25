using Core.Infrastructure.Queries;
using System.Collections.Generic;

namespace Module.Payments.Domain
{
    public class GetPaymentsQuery : IQuery<IEnumerable<PaymentDto>>
    {
    }
}
