using Core.Infrastructure.Commands;

namespace Module.Sales.Domain.InvoicePayments
{
    public class DeleteInvoicePaymentCommand : ICommand<long>
    {
        public long Id { get; set; }
    }
}
