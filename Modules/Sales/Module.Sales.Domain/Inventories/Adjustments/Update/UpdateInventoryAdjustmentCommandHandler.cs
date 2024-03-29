﻿using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain
{
    public class UpdateInventoryAdjustmentCommandHandler : ICommandHandler<UpdateInventoryAdjustmentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemService _productService;

        public UpdateInventoryAdjustmentCommandHandler(
            IUnitOfWork unitOfWork,
            IItemService productService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        public async Task<long> Handle(UpdateInventoryAdjustmentCommand request, CancellationToken cancellationToken)
        {
            await _productService.CheckDuplicate(request.LineItems.Select(x => x.ProductId), cancellationToken);

            var adjustmentRepo = _unitOfWork.GetRepository<InventoryAdjustment>();
            var adjustment = await adjustmentRepo.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken); ;

            if (adjustment == null)
                throw new ValidationException("Adjustment not found");

            request.Map(adjustment);

            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            var savedItems = await lineItemRepo
                .ListAsyncAsReadOnly(x => x.DocumentId == request.Id && x.TransactionType == LineTransactionType.Adjustment && !x.IsDeleted, x => new
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    QuantityAdjusted = x.Quantity
                }, cancellationToken);

            var productRepo = _unitOfWork.GetRepository<Item>();
            foreach (var requestLineItem in request.LineItems)
            {
                var requestProduct = await productRepo
                    .FirstOrDefaultAsyncAsReadOnly(x => x.Id == requestLineItem.ProductId && !x.IsDeleted, x => new
                    {
                        Id = x.Id,
                        // TODO StockQuantity = x.StockQuantity
                    }, cancellationToken);

                if (requestProduct == null)
                    throw new ValidationException($"Product not found.");

                var savedItem = savedItems.FirstOrDefault(x => x.Id == requestLineItem.Id);
                if (savedItem == null)
                {
                    // new
                    var _item = savedItems.FirstOrDefault(x => x.ProductId == requestLineItem.ProductId);
                    if (_item != null)
                        throw new ValidationException($"{_item.ProductName} is already added.");

                    /*float newStock = requestProduct.StockQuantity + requestLineItem.Quantity;

                    if (newStock < 0)
                        throw new ValidationException("Negative quantity is allowed.");*/

                    var newAdjustmentLine = requestLineItem.Map(request.Id);
                    await lineItemRepo.AddAsync(newAdjustmentLine);

                    // adjust product stock
                    // TODO await _productService.UpdateStockQuantity(requestLineItem.ProductId, newStock);
                }
                else
                {
                    // existing
                    if (savedItem.ProductId != requestLineItem.ProductId)
                    {
                        // product changed
                    }
                }
            }

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
