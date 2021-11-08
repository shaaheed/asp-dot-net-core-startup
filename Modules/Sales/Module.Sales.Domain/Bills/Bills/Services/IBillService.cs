using Msi.Service.Abstractions;

namespace Module.Sales.Domain
{
    public interface IBillService : IScopedService
    {
        string GetNextBillNumber();
    }
}
