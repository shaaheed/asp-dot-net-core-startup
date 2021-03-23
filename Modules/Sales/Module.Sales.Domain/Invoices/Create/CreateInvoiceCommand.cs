using Modules.Sales.Domain.Invoices;
using Msi.Mediator.Abstractions;

namespace Module.Sales.Domain.Invoices
{
    public class CreateInvoiceCommand : InvoiceRequestDto, ICommand<long>
    {
        //
    }
}
