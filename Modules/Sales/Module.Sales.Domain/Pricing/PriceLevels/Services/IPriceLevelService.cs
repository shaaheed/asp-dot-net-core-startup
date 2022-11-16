using Module.Sales.Entities;
using Msi.Domain.Abstractions;
using Msi.Service.Abstractions;

namespace Module.Sales.Domain
{
    public interface IPriceLevelService : ICrudService<PriceLevel>, IScopedService
    {
    }
}
