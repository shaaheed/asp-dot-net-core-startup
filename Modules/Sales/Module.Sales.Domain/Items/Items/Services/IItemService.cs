using Module.Sales.Domain.Items;
using Module.Sales.Entities;
using Msi.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public interface IItemService : IScopedService
    {
        Task CheckDuplicate(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        string GetNextNumber();

        Task<int> UpdateStockQuantity(Guid itemId, float newQuantity, CancellationToken cancellationToken = default);

        //Task<int> UpdateStockQuantityWithInventoryAdjustment(string reference, InventoryAdjustmentType adjustmentType, Guid itemId, float newQuantity, CancellationToken cancellationToken = default);

        Task<int> IncreaseStockQuantity(Guid itemId, float quantityToBeIncrease, CancellationToken cancellationToken = default);

        //Task<int> IncreaseStockQuantityWithInventoryAdjustment(string reference, InventoryAdjustmentType adjustmentType, Guid itemId, float quantityToBeIncrease, CancellationToken cancellationToken = default);

        Task<int> DecreaseStockQuantity(Guid itemId, float quantityToBeDecrease, CancellationToken cancellationToken = default);

        //Task<int> DecreaseStockQuantityWithInventoryAdjustment(string reference, InventoryAdjustmentType adjustmentType, Guid itemId, float quantityToBeDecrease, CancellationToken cancellationToken = default);

        //Task<int> AdjustInventoryByReference(string reference, InventoryAdjustmentType adjustmentType, Guid itemId, float adjustedQuantity, CancellationToken cancellationToken = default);

        Task<TViewModel> GetItemAsReadOnly<TViewModel>(Guid itemId, Expression<Func<Item, TViewModel>> selector, CancellationToken cancellationToken = default);

        Task<bool> IsItemExists(Guid? itemId, CancellationToken cancellationToken = default);

        Task<bool> IsItemExists(Guid itemId, CancellationToken cancellationToken = default);

        Task<List<SavedItemDto>> GetSavedItems(List<Guid> itemIds, CancellationToken cancellationToken = default);

        void CheckItemNotFound(List<SavedItemDto> savedItems);

        Task CheckItemNotFound(List<Guid> itemIds, CancellationToken cancellationToken = default);

        Task CheckItemSelable(Guid? itemId, string itemName, CancellationToken cancellationToken = default);

        Task CreateOrUpdateCategories(Guid itemId, List<Guid> categories);

        Task CreateOrUpdateSaleDetails(Guid itemId, ItemSaleDetailsRequestDto saleDetailsRequest, CancellationToken cancellationToken = default);

        Task CreateOrUpdatePurchaseDetails(Guid itemId, ItemPurchaseDetailsRequestDto purchaseDetailsRequest, CancellationToken cancellationToken = default);
    }
}
