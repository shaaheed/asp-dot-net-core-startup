using Msi.Mediator.Abstractions;

namespace Module.Sales.Domain
{
    public class CreateInvoiceCommand : InvoiceRequestDto, ICommand<long>
    {
        //
    }
}
