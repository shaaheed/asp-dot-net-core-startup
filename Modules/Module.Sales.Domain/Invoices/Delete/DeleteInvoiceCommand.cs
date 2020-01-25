using Core.Infrastructure.Commands;

namespace Module.Sales.Domain.Invoices
{
    public class DeleteInvoiceCommand : ICommand<long>
    {
        public long Id { get; set; }
    }
}
