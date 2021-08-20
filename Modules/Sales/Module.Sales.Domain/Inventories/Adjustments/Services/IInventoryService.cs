using Msi.Service;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public interface IInventoryService : IScopedService
    {
        Task<int> CreateOrUpdateInventoryAdjustment(
            string reference,
            Guid productId,
            float productQuantity,
            bool increase,
            bool decrease,
            CancellationToken cancellationToken = default);
    }
}
