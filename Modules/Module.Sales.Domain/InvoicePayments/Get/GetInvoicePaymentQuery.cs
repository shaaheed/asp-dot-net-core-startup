using Core.Infrastructure.Queries;

namespace Module.Sales.Domain.InvoicePayments
{
    public class GetInvoicePaymentQuery : IQuery<InvoicePaymentDetailsDto>
    {
        public long Id { get; set; }
    }
}
