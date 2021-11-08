using Msi.Service.Abstractions;

namespace Module.Sales.Domain
{
    public interface IInvoiceService : IScopedService
    {
        string GetNextInvoiceNumber();
    }
}
