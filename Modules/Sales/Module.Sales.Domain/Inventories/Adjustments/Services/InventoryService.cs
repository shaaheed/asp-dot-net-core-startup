using Msi.Data.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<int> CreateOrUpdateInventoryAdjustment(
            string reference,
            Guid productId,
            float productQuantity,
            bool increase,
            bool decrease,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            //
        }

    }
}
