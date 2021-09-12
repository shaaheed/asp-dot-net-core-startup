using Module.Sales.Entities;
using Msi.Core;
using Msi.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public class LineItemService : ILineItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        private readonly IRepository<LineItem> _lineItemRepo;

        public LineItemService(
            IUnitOfWork unitOfWork,
            IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
            _lineItemRepo = _unitOfWork.GetRepository<LineItem>();
        }

        public async Task<int> CreateAsync(LineItemType lineItemType, Guid referenceId, List<LineItemRequestDto> requestLineItems, CancellationToken cancellationToken)
        {
            int result = 0;
            var requestProductIds = requestLineItems
                .Where(x => x.ProductId != null)
                .Select(x => x.ProductId.Value)
                .ToList();

            await _productService.CheckDuplicate(requestProductIds, cancellationToken);

            var savedProducts = await _productService.GetSavedProducts(requestProductIds, cancellationToken);
            _productService.CheckProductNotFound(savedProducts);

            var newLineItems = requestLineItems.Select(x =>
            {
                LineItem newLineItem = x.Map();
                newLineItem.Type = lineItemType;
                newLineItem.ReferenceId = referenceId;
                return newLineItem;
            });

            foreach (var savedProduct in savedProducts)
            {
                // if (!savedProduct.IsSale || savedProduct.IsDeleted) throw new ValidationException($"{savedProduct.Name} is not salable.");

                if (savedProduct.IsInventory)
                {
                    var quantityToBuy = requestLineItems
                        .Where(x => x.ProductId == savedProduct.Id)
                        .Select(x => x.Quantity)
                        .Sum();

                    if (lineItemType == LineItemType.Purchase)
                    {
                        // purchase will increase the product stock count
                        result += await _productService.IncreaseStockQuantity(savedProduct.Id, quantityToBuy, cancellationToken);
                    }
                    else if (lineItemType == LineItemType.Sale)
                    {
                        // sale will decrease the product stock count
                        result += await _productService.DecreaseStockQuantity(savedProduct.Id, quantityToBuy, cancellationToken);
                    }

                }
            }

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }

        public async Task<int> UpdateAsync(LineItemType lineItemType, Guid referenceId, List<LineItemRequestDto> requestLineItems, CancellationToken cancellationToken)
        {
            var requestProductIds = requestLineItems
                .Where(x => x.ProductId != null)
                .Select(x => x.ProductId.Value)
                .ToList();
            await _productService.CheckDuplicate(requestProductIds, cancellationToken);

            var savedProducts = await _productService.GetSavedProducts(requestProductIds, cancellationToken);
            _productService.CheckProductNotFound(savedProducts);

            var lineItems = new List<LineItem>();

            var savedLineItems = await _lineItemRepo
                .ListAsyncAsReadOnly(x => x.ReferenceId == referenceId && x.Type == lineItemType && !x.IsDeleted, x => new
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    LineItemQuantity = x.Quantity
                }, cancellationToken);

            var result = 0;
            foreach (var requestLineItem in requestLineItems)
            {
                if (requestLineItem.Id.HasValue)
                {
                    // line item will be update
                    var savedLineItem = savedLineItems.FirstOrDefault(x => x.Id == requestLineItem.Id);

                    if (savedLineItem == null)
                        throw new ValidationException("Line item not found");

                    result += await CreateOrUpdate(requestLineItem, lineItemType, referenceId, cancellationToken);

                    // line item product changed
                    if (requestLineItem.ProductId.HasValue && savedLineItem.ProductId.HasValue && requestLineItem.ProductId.Value != savedLineItem.ProductId.Value)
                    {
                        if (lineItemType == LineItemType.Purchase)
                        {
                            // increasing product stock as new product is added to bill line item
                            result += await _productService.IncreaseStockQuantity(requestLineItem.ProductId.Value, requestLineItem.Quantity, cancellationToken);

                            // decreasing product stock as product is removed from bill line item
                            result += await _productService.DecreaseStockQuantity(savedLineItem.ProductId.Value, savedLineItem.LineItemQuantity, cancellationToken);
                        }
                        else if (lineItemType == LineItemType.Sale)
                        {
                            // reducing product stock as new product is added to invoice line item
                            result += await _productService.DecreaseStockQuantity(requestLineItem.ProductId.Value, requestLineItem.Quantity, cancellationToken);

                            // increasing product stock as product is removed from invoice line item
                            result += await _productService.IncreaseStockQuantity(savedLineItem.ProductId.Value, savedLineItem.LineItemQuantity, cancellationToken);
                        }

                    }

                    // line item product not changed but quantiy may changed
                    else if (requestLineItem.ProductId.HasValue && savedLineItem.ProductId.HasValue && requestLineItem.ProductId.Value == savedLineItem.ProductId.Value)
                    {
                        if (requestLineItem.Quantity > savedLineItem.LineItemQuantity)
                        {
                            // product stock quantity will be increase
                            var quantityToBeIncrease = requestLineItem.Quantity - savedLineItem.LineItemQuantity;
                            result += await _productService.IncreaseStockQuantity(requestLineItem.ProductId.Value, quantityToBeIncrease, cancellationToken);
                        }
                        else if (requestLineItem.Quantity < savedLineItem.LineItemQuantity)
                        {
                            // product stock quantity will be increase
                            var quantityToBeDecrease = savedLineItem.LineItemQuantity - requestLineItem.Quantity;
                            result += await _productService.DecreaseStockQuantity(requestLineItem.ProductId.Value, quantityToBeDecrease, cancellationToken);
                        }
                    }

                    else if (requestLineItem.ProductId.HasValue && !savedLineItem.ProductId.HasValue)
                    {
                        // new product added to line item
                        // product stock quantity will be increase
                        result += await _productService.IncreaseStockQuantity(requestLineItem.ProductId.Value, requestLineItem.Quantity, cancellationToken);
                    }

                    else if (!requestLineItem.ProductId.HasValue && savedLineItem.ProductId.HasValue)
                    {
                        // product removed from line item
                        // product stock quantity will be decrease
                        result += await _productService.DecreaseStockQuantity(savedLineItem.ProductId.Value, savedLineItem.LineItemQuantity, cancellationToken);
                    }
                }
                else
                {
                    if (requestLineItem.ProductId.HasValue)
                    {
                        await _productService.CheckProductSelable(requestLineItem.ProductId, requestLineItem.Name, cancellationToken);

                        result += await _productService.IncreaseStockQuantity(requestLineItem.ProductId.Value, requestLineItem.Quantity, cancellationToken);
                    }

                    result += await CreateOrUpdate(requestLineItem, lineItemType, referenceId, cancellationToken);
                }
            }

            var deletedLineItems = new List<LineItem>();
            foreach (var savedLineItem in savedLineItems)
            {
                var requestItem = requestLineItems.FirstOrDefault(x => x.Id == savedLineItem.Id);
                if (requestItem == null)
                {
                    // delete saved item
                    deletedLineItems.Add(new LineItem { Id = savedLineItem.Id });

                    // decrease product stock as product line item is deleted
                    if (savedLineItem.ProductId.HasValue)
                    {
                        await _productService.DecreaseStockQuantity(savedLineItem.ProductId.Value, savedLineItem.LineItemQuantity, cancellationToken);
                    }
                }
            }

            _lineItemRepo.RemoveRange(deletedLineItems);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteAsync(LineItemType lineItemType, Guid referenceId, CancellationToken cancellationToken)
        {
            var savedLineItems = await _lineItemRepo.ListAsyncAsReadOnly(x => x.Type == lineItemType && x.ReferenceId == referenceId, x => new LineItem
            { Id = x.Id }, cancellationToken);

            _lineItemRepo.RemoveRange(savedLineItems);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CreateOrUpdate(
            LineItemRequestDto request,
            LineItemType type,
            Guid referenceId,
            CancellationToken cancellationToken = default)
        {
            var lineItem = request.Map();
            if (request.Id.HasValue)
            {
                var savedLineItem = await _unitOfWork
                    .GetRepository<LineItem>()
                    .FirstOrDefaultAsyncAsReadOnly(x => x.Id == request.Id.Value && x.ReferenceId == referenceId && x.Type == type && !x.IsDeleted, x => new { Id = x.Id }, cancellationToken);

                if (savedLineItem == null)
                    throw new ValidationException("Line item not found.");

                lineItem.Id = request.Id.Value;
                _lineItemRepo.Attach(lineItem);
            }
            else
            {
                lineItem.Type = type;
                lineItem.ReferenceId = referenceId;
                await _lineItemRepo.AddAsync(lineItem, cancellationToken);
            }
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
