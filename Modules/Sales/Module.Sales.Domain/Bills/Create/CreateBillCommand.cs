using Msi.Mediator.Abstractions;

namespace Module.Sales.Domain.Bills
{
    public class CreateBillCommand : InvoiceRequestDto, ICommand<long>
    {
    }
}
