using Module.Sales.Domain.Items;
using Module.Sales.Entities;
using Msi.Core;
using Msi.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Item> _repository;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Item>();
        }

        public async Task CheckDuplicate(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            var duplicateIds = ids.Except(ids.Distinct());
            if (duplicateIds.Count() > 0)
            {
                var duplicateItem = await _repository
                    .FirstOrDefaultAsyncAsReadOnly(x => x.Id == duplicateIds.First() && !x.IsDeleted, x => x.Name, cancellationToken);
                throw new ValidationException($"{duplicateItem} is a duplicate entry.");
            }
        }

        public async Task<int> DecreaseStockQuantity(Guid itemId, float quantityToBeDecrease, CancellationToken cancellationToken = default)
        {
            var savedItem = await GetItemAsReadOnly(itemId, x => new
            {
                // TODO StockQuantity = x.StockQuantity,
                Name = x.Name
            }, cancellationToken);

            if (quantityToBeDecrease <= 0)
                throw new ValidationException($"{savedItem.Name} quantity can not be zero or negative.");

            var item = new Item { Id = itemId };
            _repository.Attach(item);

            /*var _newQuantity = savedItem.StockQuantity - quantityToBeDecrease;
            if (_newQuantity < 0)
                throw new ValidationException($"{savedItem.Name} stock quantity can not be negative.");

            item.StockQuantity = _newQuantity;*/

            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        //public async Task<int> DecreaseStockQuantityWithInventoryAdjustment(string reference, InventoryAdjustmentType adjustmentType, Guid itemId, float quantityToBeDecrease, CancellationToken cancellationToken = default)
        //{
        //    var result = await DecreaseStockQuantity(itemId, quantityToBeDecrease, cancellationToken);
        //    result += await AdjustInventoryByReference(reference, adjustmentType, itemId, -quantityToBeDecrease, cancellationToken);
        //    return result;
        //}
        public string GetNextNumber()
        {
            var count = _repository
                .WhereAsReadOnly(x => !x.IsDeleted)
                .Select(x => x.Id)
                .LongCount();

            return $"PR-{count + 1}";
        }

        public async Task<int> IncreaseStockQuantity(Guid itemId, float quantityToBeIncrease, CancellationToken cancellationToken = default)
        {
            var savedItem = await GetItemAsReadOnly(itemId, x => new
            {
                // TODO StockQuantity = x.StockQuantity
            }, cancellationToken);

            var item = new Item { Id = itemId };
            //_repository.Attach(item);

            /*var _newQuantity = savedItem.StockQuantity + quantityToBeIncrease;
            item.StockQuantity = _newQuantity;*/

            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        //public async Task<int> IncreaseStockQuantityWithInventoryAdjustment(string reference, InventoryAdjustmentType adjustmentType, Guid itemId, float quantityToBeIncrease, CancellationToken cancellationToken = default)
        //{
        //    var result = await IncreaseStockQuantity(itemId, quantityToBeIncrease, cancellationToken);
        //    result += await AdjustInventoryByReference(reference, adjustmentType, itemId, quantityToBeIncrease, cancellationToken);
        //    return result;
        //}
        public async Task<int> UpdateStockQuantity(Guid itemId, float newQuantity, CancellationToken cancellationToken = default)
        {
            int result = 0;
            var savedItem = await GetItemAsReadOnly(itemId, x => new
            {
                // TODO StockQuantity = x.StockQuantity,
                Name = x.Name
            }, cancellationToken);

            // 10 < 15 = 5
            /*if (savedItem.StockQuantity < newQuantity)
            {
                // increase
                float quantityToBeIncrease = newQuantity - savedItem.StockQuantity;
                result += await IncreaseStockQuantity(itemId, quantityToBeIncrease, cancellationToken);
            }
            // 15 > 10 = 5
            else if (savedItem.StockQuantity > newQuantity)
            {
                // decrease
                float quantityToBeDecrease = savedItem.StockQuantity - newQuantity;
                result += await DecreaseStockQuantity(itemId, quantityToBeDecrease, cancellationToken);
            }*/
            return result;
        }

        //public async Task<int> UpdateStockQuantityWithInventoryAdjustment(string reference, InventoryAdjustmentType adjustmentType, Guid itemId, float newQuantity, CancellationToken cancellationToken = default)
        //{
        //    int result = 0;
        //    var savedItem = await GetItemAsReadOnly(itemId, x => new
        //    {
        //        StockQuantity = x.StockQuantity,
        //        Name = x.Name
        //    }, cancellationToken);

        //    // 10 < 15 = 5
        //    if (savedItem.StockQuantity < newQuantity)
        //    {
        //        // increase
        //        float quantityToBeIncrease = newQuantity - savedItem.StockQuantity;
        //        result += await IncreaseStockQuantityWithInventoryAdjustment(reference, adjustmentType, itemId, quantityToBeIncrease, cancellationToken);
        //    }
        //    // 15 > 10 = 5
        //    else if (savedItem.StockQuantity > newQuantity)
        //    {
        //        // decrease
        //        float quantityToBeDecrease = savedItem.StockQuantity - newQuantity;
        //        result += await DecreaseStockQuantityWithInventoryAdjustment(reference, adjustmentType, itemId, quantityToBeDecrease, cancellationToken);
        //    }
        //    return result;
        //}
        /// <summary>
        /// This method must be called after updating the item stock quantity
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="itemId"></param>
        /// <param name="quantityAdjusted"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //public async Task<int> AdjustInventoryByReference(
        //    string reference,
        //    InventoryAdjustmentType adjustmentType,
        //    Guid itemId,
        //    float quantityAdjusted,
        //    CancellationToken cancellationToken = default)
        //{
        //    var savedItem = await GetItemAsReadOnly(itemId, x => new
        //    {
        //        Id = x.Id,
        //        StockQuantity = x.StockQuantity,
        //        IsSale = x.IsSale,
        //        IsInventory = x.IsInventory,
        //        Name = x.Name
        //    }, cancellationToken);

        //    if (!savedItem.IsSale) throw new ValidationException($"{savedItem.Name} is not salable.");

        //    int result = 0;
        //    if (savedItem.IsInventory)
        //    {
        //        var adjustmentLineRepo = _unitOfWork.GetRepository<InventoryAdjustmentLineItem>();

        //        var savedAdjustmentLines = await adjustmentLineRepo
        //            .ListAsyncAsReadOnly(x => x.InventoryAdjustment.Reference == reference && x.ItemId == itemId && !x.InventoryAdjustment.IsDeleted, x => new
        //            {
        //                Id = x.Id,
        //                QuantityAdjusted = x.QuantityAdjusted
        //            }, cancellationToken);

        //        if (savedAdjustmentLines.Count > 0)
        //        {
        //            var linesToBeDeleted = savedAdjustmentLines.Skip(1).Select(x => new InventoryAdjustmentLineItem { Id = x.Id });
        //            adjustmentLineRepo.RemoveRange(linesToBeDeleted);

        //            // update
        //            var adjustmentLine = new InventoryAdjustmentLineItem { Id = savedAdjustmentLines[0].Id };
        //            adjustmentLineRepo.Attach(adjustmentLine);
        //            adjustmentLine.QuantityAdjusted = quantityAdjusted;
        //            adjustmentLine.NewQuantityOnHand = savedItem.StockQuantity;
        //            adjustmentLine.QuantityAvailable = savedItem.StockQuantity;
        //            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
        //        }
        //        else
        //        {
        //            // new
        //            var _newAdjustment = new InventoryAdjustmentLineItem
        //            {
        //                InventoryAdjustment = new InventoryAdjustment
        //                {
        //                    AdjustmentDate = DateTimeOffset.UtcNow,
        //                    Reference = reference,
        //                    Type = adjustmentType
        //                },
        //                ItemId = itemId,
        //                QuantityAdjusted = quantityAdjusted,
        //                QuantityAvailable = savedItem.StockQuantity,
        //                NewQuantityOnHand = savedItem.StockQuantity
        //            };
        //            await adjustmentLineRepo.AddAsync(_newAdjustment, cancellationToken);
        //            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
        //        }
        //    }
        //    return result;
        //}

        public async Task<TViewModel> GetItemAsReadOnly<TViewModel>(Guid itemId, Expression<Func<Item, TViewModel>> selector, CancellationToken cancellationToken = default)
        {
            var item = await _repository.FirstOrDefaultAsyncAsReadOnly(x => x.Id == itemId && !x.IsDeleted, selector, cancellationToken);

            if (item == null)
                throw new ValidationException("Item not found");

            return item;
        }

        public async Task<bool> IsItemExists(Guid? itemId, CancellationToken cancellationToken = default)
        {
            if (!itemId.HasValue) return false;

            return await IsItemExists(itemId.Value, cancellationToken);
        }

        public async Task<bool> IsItemExists(Guid itemId, CancellationToken cancellationToken = default)
        {
            var item = await GetItemAsReadOnly(itemId, x => new { Id = x.Id }, cancellationToken);
            return item != null;
        }

        public Task<List<SavedItemDto>> GetSavedItems(List<Guid> itemIds, CancellationToken cancellationToken = default)
        {
            return _repository
                .ListAsyncAsReadOnly(x => itemIds.Contains(x.Id), x => new SavedItemDto
                {
                    Id = x.Id,
                    // TODO StockQuantity = x.StockQuantity,
                    Name = x.Name,
                    IsInventory = x.IsInventory,
                    IsSale = x.IsSale,
                    IsDeleted = x.IsDeleted
                }, cancellationToken);
        }

        public void CheckItemNotFound(List<SavedItemDto> savedItems)
        {
            var itemIds = savedItems.Select(x => x.Id);
            var notFoundItems = savedItems
                .Where(x => !itemIds.Contains(x.Id))
                .ToList();

            if (notFoundItems.Count() > 0)
                throw new ValidationException($"{notFoundItems[0].Name} not found.");
        }

        public async Task CheckItemNotFound(List<Guid> itemIds, CancellationToken cancellationToken = default)
        {
            var savedItems = await GetSavedItems(itemIds, cancellationToken);
            CheckItemNotFound(savedItems);
        }

        public async Task CheckItemSelable(Guid? itemId, string itemName, CancellationToken cancellationToken = default)
        {
            if (itemId.HasValue)
            {
                var item = await GetItemAsReadOnly(itemId.Value, x => new
                {
                    Name = itemName,
                    IsInventory = x.IsInventory,
                    IsSale = x.IsSale,
                    IsDeleted = x.IsDeleted
                }, cancellationToken);

                if (item == null)
                    throw new ValidationException($"{item.Name} item not found");

                if (!item.IsSale || !item.IsInventory || item.IsDeleted)
                    throw new ValidationException($"{item.Name} item is not salable");
            }
        }

        public Task CreateOrUpdateCategories(Guid itemId, List<Guid> categories)
        {
            if (categories != null)
            {
                return _unitOfWork.GetRepository<ItemCategory>()
                        .UpdateAsync(
                        categories,
                        x => x.ItemId == itemId,
                        x => x.CategoryId,
                        x => new ItemCategory
                        {
                            ItemId = itemId,
                            CategoryId = x,
                        },
                        ids => x => ids.Contains(x.CategoryId) && x.ItemId == itemId);
            }
            return Task.CompletedTask;
        }

        public async Task CreateOrUpdateSaleDetails(Guid itemId, ItemSaleDetailsRequestDto saleDetailsRequest, CancellationToken cancellationToken = default)
        {
            if (saleDetailsRequest != null)
            {
                var saleRepo = _unitOfWork.GetRepository<ItemSaleDetails>();
                var saleDetails = await saleRepo.FirstOrDefaultAsync(x => x.ItemId == itemId);
                if (saleDetails != null)
                {
                    // update
                    saleDetailsRequest?.Map(saleDetails);
                }
                else
                {
                    // create
                    saleDetails = saleDetailsRequest.Map();
                    saleDetails.ItemId = itemId;
                    await saleRepo.AddAsync(saleDetails, cancellationToken);
                    var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                if (saleDetailsRequest.Currencies != null)
                {
                    await _unitOfWork.GetRepository<ItemSaleDetailsCurrency>()
                            .UpdateAsync(
                            saleDetailsRequest.Currencies,
                            x => x.ItemSaleDetailsId == saleDetails.Id,
                            x => x.CurrencyId,
                            x => new ItemSaleDetailsCurrency
                            {
                                ItemSaleDetailsId = saleDetails.Id,
                                CurrencyId = x,
                            },
                            ids => x => ids.Contains(x.CurrencyId) && x.ItemSaleDetailsId == saleDetails.Id);
                }
            }
        }

        public async Task CreateOrUpdatePurchaseDetails(Guid itemId, ItemPurchaseDetailsRequestDto purchaseDetailsRequest, CancellationToken cancellationToken = default)
        {
            if (purchaseDetailsRequest != null)
            {
                var purchaseRepo = _unitOfWork.GetRepository<ItemPurchaseDetails>();
                var purchaseDetails = await purchaseRepo.FirstOrDefaultAsync(x => x.ItemId == itemId);
                if (purchaseDetails != null)
                {
                    // update
                    purchaseDetailsRequest?.Map(purchaseDetails);
                }
                else
                {
                    // create
                    purchaseDetails = purchaseDetailsRequest.Map();
                    purchaseDetails.ItemId = itemId;
                    await purchaseRepo.AddAsync(purchaseDetails, cancellationToken);
                    var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

                }
                if (purchaseDetailsRequest.Currencies != null)
                {
                    await _unitOfWork.GetRepository<ItemPurchaseDetailsCurrency>()
                            .UpdateAsync(
                            purchaseDetailsRequest.Currencies,
                            x => x.ItemPurchaseDetailsId == purchaseDetails.Id,
                            x => x.CurrencyId,
                            x => new ItemPurchaseDetailsCurrency
                            {
                                ItemPurchaseDetailsId = purchaseDetails.Id,
                                CurrencyId = x,
                            },
                            ids => x => ids.Contains(x.CurrencyId) && x.ItemPurchaseDetailsId == purchaseDetails.Id);
                }
            }
        }
    }
}
