using Core.Infrastructure.Queries;

namespace Module.Payments.Domain
{
    public class GetPaymentQuery : IQuery<PaymentDetailsDto>
    {
        public long Id { get; set; }
    }
}
