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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Item> _repository;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Item>();
        }

        public async Task CheckDuplicate(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            var duplicateIds = ids.Except(ids.Distinct());
            if (duplicateIds.Count() > 0)
            {
                var duplicateProduct = await _repository
                    .FirstOrDefaultAsyncAsReadOnly(x => x.Id == duplicateIds.First() && !x.IsDeleted, x => x.Name, cancellationToken);
                throw new ValidationException($"{duplicateProduct} is a duplicate entry.");
            }
        }

        public async Task<int> DecreaseStockQuantity(Guid productId, float quantityToBeDecrease, CancellationToken cancellationToken = default)
        {
            var savedProduct = await GetProductAsReadOnly(productId, x => new
            {
                // TODO StockQuantity = x.StockQuantity,
                Name = x.Name
            }, cancellationToken);

            if (quantityToBeDecrease <= 0)
                throw new ValidationException($"{savedProduct.Name} quantity can not be zero or negative.");

            var product = new Item { Id = productId };
            _repository.Attach(product);

            /*var _newQuantity = savedProduct.StockQuantity - quantityToBeDecrease;
            if (_newQuantity < 0)
                throw new ValidationException($"{savedProduct.Name} stock quantity can not be negative.");

            product.StockQuantity = _newQuantity;*/

            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        //public async Task<int> DecreaseStockQuantityWithInventoryAdjustment(string reference, InventoryAdjustmentType adjustmentType, Guid productId, float quantityToBeDecrease, CancellationToken cancellationToken = default)
        //{
        //    var result = await DecreaseStockQuantity(productId, quantityToBeDecrease, cancellationToken);
        //    result += await AdjustInventoryByReference(reference, adjustmentType, productId, -quantityToBeDecrease, cancellationToken);
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

        public async Task<int> IncreaseStockQuantity(Guid productId, float quantityToBeIncrease, CancellationToken cancellationToken = default)
        {
            var savedProduct = await GetProductAsReadOnly(productId, x => new
            {
                // TODO StockQuantity = x.StockQuantity
            }, cancellationToken);

            var product = new Item { Id = productId };
            //_repository.Attach(product);

            /*var _newQuantity = savedProduct.StockQuantity + quantityToBeIncrease;
            product.StockQuantity = _newQuantity;*/

            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        //public async Task<int> IncreaseStockQuantityWithInventoryAdjustment(string reference, InventoryAdjustmentType adjustmentType, Guid productId, float quantityToBeIncrease, CancellationToken cancellationToken = default)
        //{
        //    var result = await IncreaseStockQuantity(productId, quantityToBeIncrease, cancellationToken);
        //    result += await AdjustInventoryByReference(reference, adjustmentType, productId, quantityToBeIncrease, cancellationToken);
        //    return result;
        //}

        public async Task<int> UpdateStockQuantity(Guid productId, float newQuantity, CancellationToken cancellationToken = default)
        {
            int result = 0;
            var savedProduct = await GetProductAsReadOnly(productId, x => new
            {
                // TODO StockQuantity = x.StockQuantity,
                Name = x.Name
            }, cancellationToken);

            // 10 < 15 = 5
            /*if (savedProduct.StockQuantity < newQuantity)
            {
                // increase
                float quantityToBeIncrease = newQuantity - savedProduct.StockQuantity;
                result += await IncreaseStockQuantity(productId, quantityToBeIncrease, cancellationToken);
            }
            // 15 > 10 = 5
            else if (savedProduct.StockQuantity > newQuantity)
            {
                // decrease
                float quantityToBeDecrease = savedProduct.StockQuantity - newQuantity;
                result += await DecreaseStockQuantity(productId, quantityToBeDecrease, cancellationToken);
            }*/
            return result;
        }

        //public async Task<int> UpdateStockQuantityWithInventoryAdjustment(string reference, InventoryAdjustmentType adjustmentType, Guid productId, float newQuantity, CancellationToken cancellationToken = default)
        //{
        //    int result = 0;
        //    var savedProduct = await GetProductAsReadOnly(productId, x => new
        //    {
        //        StockQuantity = x.StockQuantity,
        //        Name = x.Name
        //    }, cancellationToken);

        //    // 10 < 15 = 5
        //    if (savedProduct.StockQuantity < newQuantity)
        //    {
        //        // increase
        //        float quantityToBeIncrease = newQuantity - savedProduct.StockQuantity;
        //        result += await IncreaseStockQuantityWithInventoryAdjustment(reference, adjustmentType, productId, quantityToBeIncrease, cancellationToken);
        //    }
        //    // 15 > 10 = 5
        //    else if (savedProduct.StockQuantity > newQuantity)
        //    {
        //        // decrease
        //        float quantityToBeDecrease = savedProduct.StockQuantity - newQuantity;
        //        result += await DecreaseStockQuantityWithInventoryAdjustment(reference, adjustmentType, productId, quantityToBeDecrease, cancellationToken);
        //    }
        //    return result;
        //}

        /// <summary>
        /// This method must be called after updating the product stock quantity
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="productId"></param>
        /// <param name="quantityAdjusted"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //public async Task<int> AdjustInventoryByReference(
        //    string reference,
        //    InventoryAdjustmentType adjustmentType,
        //    Guid productId,
        //    float quantityAdjusted,
        //    CancellationToken cancellationToken = default)
        //{
        //    var savedProduct = await GetProductAsReadOnly(productId, x => new
        //    {
        //        Id = x.Id,
        //        StockQuantity = x.StockQuantity,
        //        IsSale = x.IsSale,
        //        IsInventory = x.IsInventory,
        //        Name = x.Name
        //    }, cancellationToken);

        //    if (!savedProduct.IsSale) throw new ValidationException($"{savedProduct.Name} is not salable.");

        //    int result = 0;
        //    if (savedProduct.IsInventory)
        //    {
        //        var adjustmentLineRepo = _unitOfWork.GetRepository<InventoryAdjustmentLineItem>();

        //        var savedAdjustmentLines = await adjustmentLineRepo
        //            .ListAsyncAsReadOnly(x => x.InventoryAdjustment.Reference == reference && x.ProductId == productId && !x.InventoryAdjustment.IsDeleted, x => new
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
        //            adjustmentLine.NewQuantityOnHand = savedProduct.StockQuantity;
        //            adjustmentLine.QuantityAvailable = savedProduct.StockQuantity;
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
        //                ProductId = productId,
        //                QuantityAdjusted = quantityAdjusted,
        //                QuantityAvailable = savedProduct.StockQuantity,
        //                NewQuantityOnHand = savedProduct.StockQuantity
        //            };
        //            await adjustmentLineRepo.AddAsync(_newAdjustment, cancellationToken);
        //            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
        //        }
        //    }
        //    return result;
        //}

        public async Task<TViewModel> GetProductAsReadOnly<TViewModel>(Guid productId, Expression<Func<Item, TViewModel>> selector, CancellationToken cancellationToken = default)
        {
            var product = await _repository.FirstOrDefaultAsyncAsReadOnly(x => x.Id == productId && !x.IsDeleted, selector, cancellationToken);

            if (product == null)
                throw new ValidationException("Product not found");

            return product;
        }

        public async Task<bool> IsProductExists(Guid? productId, CancellationToken cancellationToken = default)
        {
            if (!productId.HasValue) return false;

            return await IsProductExists(productId.Value, cancellationToken);
        }

        public async Task<bool> IsProductExists(Guid productId, CancellationToken cancellationToken = default)
        {
            var product = await GetProductAsReadOnly(productId, x => new { Id = x.Id }, cancellationToken);
            return product != null;
        }

        public Task<List<SavedProductDto>> GetSavedProducts(List<Guid> productIds, CancellationToken cancellationToken = default)
        {
            return _repository
                .ListAsyncAsReadOnly(x => productIds.Contains(x.Id), x => new SavedProductDto
                {
                    Id = x.Id,
                    // TODO StockQuantity = x.StockQuantity,
                    Name = x.Name,
                    IsInventory = x.IsInventory,
                    IsSale = x.IsSale,
                    IsDeleted = x.IsDeleted
                }, cancellationToken);
        }

        public void CheckProductNotFound(List<SavedProductDto> savedProducts)
        {
            var productIds = savedProducts.Select(x => x.Id);
            var notFoundProducts = savedProducts
                .Where(x => !productIds.Contains(x.Id))
                .ToList();

            if (notFoundProducts.Count() > 0)
                throw new ValidationException($"{notFoundProducts[0].Name} not found.");
        }

        public async Task CheckProductNotFound(List<Guid> productIds, CancellationToken cancellationToken = default)
        {
            var savedProducts = await GetSavedProducts(productIds, cancellationToken);
            CheckProductNotFound(savedProducts);
        }

        public async Task CheckProductSelable(Guid? productId, string productName, CancellationToken cancellationToken = default)
        {
            if (productId.HasValue)
            {
                var product = await GetProductAsReadOnly(productId.Value, x => new
                {
                    Name = productName,
                    IsInventory = x.IsInventory,
                    IsSale = x.IsSale,
                    IsDeleted = x.IsDeleted
                }, cancellationToken);

                if (product == null)
                    throw new ValidationException($"{product.Name} product not found");

                if (!product.IsSale || !product.IsInventory || product.IsDeleted)
                    throw new ValidationException($"{product.Name} product is not salable");
            }
        }
    }
}
