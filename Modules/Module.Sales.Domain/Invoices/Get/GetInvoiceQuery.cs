using Core.Infrastructure.Queries;

namespace Module.Sales.Domain.Invoices
{
    public class GetInvoiceQuery : IQuery<InvoiceDetailsDto>
    {
        public long Id { get; set; }
    }
}
