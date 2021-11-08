using Module.Payments.Domain;
using Msi.Mediator.Abstractions;

namespace Module.Sales.Domain
{
    public class GetBillPaymentQuery : GetPaymentQuery, IQuery<PaymentDetailsDto>
    {
        //
    }
}
