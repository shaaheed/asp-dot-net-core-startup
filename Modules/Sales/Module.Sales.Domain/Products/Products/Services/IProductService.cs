using Module.Sales.Entities;
using Msi.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public interface IProductService : IScopedService
    {
        Task CheckDuplicate(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        string GetNextNumber();

        Task<int> UpdateStockQuantity(Guid productId, float newQuantity, CancellationToken cancellationToken = default);

        //Task<int> UpdateStockQuantityWithInventoryAdjustment(string reference, InventoryAdjustmentType adjustmentType, Guid productId, float newQuantity, CancellationToken cancellationToken = default);

        Task<int> IncreaseStockQuantity(Guid productId, float quantityToBeIncrease, CancellationToken cancellationToken = default);

        //Task<int> IncreaseStockQuantityWithInventoryAdjustment(string reference, InventoryAdjustmentType adjustmentType, Guid productId, float quantityToBeIncrease, CancellationToken cancellationToken = default);

        Task<int> DecreaseStockQuantity(Guid productId, float quantityToBeDecrease, CancellationToken cancellationToken = default);

        //Task<int> DecreaseStockQuantityWithInventoryAdjustment(string reference, InventoryAdjustmentType adjustmentType, Guid productId, float quantityToBeDecrease, CancellationToken cancellationToken = default);

        //Task<int> AdjustInventoryByReference(string reference, InventoryAdjustmentType adjustmentType, Guid productId, float adjustedQuantity, CancellationToken cancellationToken = default);

        Task<TViewModel> GetProductAsReadOnly<TViewModel>(Guid productId, Expression<Func<Product, TViewModel>> selector, CancellationToken cancellationToken = default);

        Task<bool> IsProductExists(Guid? productId, CancellationToken cancellationToken = default);

        Task<bool> IsProductExists(Guid productId, CancellationToken cancellationToken = default);

        Task<List<SavedProductDto>> GetSavedProducts(List<Guid> productIds, CancellationToken cancellationToken = default);

        void CheckProductNotFound(List<SavedProductDto> savedProducts);

        Task CheckProductNotFound(List<Guid> productIds, CancellationToken cancellationToken = default);

        Task CheckProductSelable(Guid? productId, string productName, CancellationToken cancellationToken = default);
    }
}
