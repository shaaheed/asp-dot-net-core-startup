using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Payments.Domain
{
    public class GetPaymentMethodsQuery : Query<PagedCollection<PaymentMethodDto>>
    {
    }
}
