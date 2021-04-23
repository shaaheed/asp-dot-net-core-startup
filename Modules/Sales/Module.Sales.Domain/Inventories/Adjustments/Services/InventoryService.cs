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
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateOrUpdateInventoryAdjustment(
            string reference,
            Guid productId,
            float productQuantity,
            bool increase,
            bool decrease,
            CancellationToken cancellationToken = default)
        {

            if (increase != decrease)
            {
                throw new ValidationException("Can not increase or decrease product quantity at the same time");
            }

            var productRepo = _unitOfWork.GetRepository<Product>();
            var product = productRepo
                .Where(x => x.Id == productId && !x.IsDeleted)
                .Select(x => new
                {
                    Id = x.Id,
                    Stock = x.StockQuantity,
                    IsSale = x.IsSale,
                    IsInventory = x.IsInventory,
                    Name = x.Name
                })
                .FirstOrDefault();

            if (product == null)
                throw new ValidationException("Product not found.");

            if (!product.IsSale) throw new ValidationException($"{product.Name} is not salable.");

            int result = 0;
            if (product.IsInventory)
            {
                float newStock = 0;
                if (increase)
                {
                    newStock = product.Stock + productQuantity;
                }
                else if (decrease)
                {
                    if (product.Stock < productQuantity)
                    {
                        throw new ValidationException($"{product.Name} out of stock");
                    }
                    newStock = product.Stock - productQuantity;
                }

                var adjustmentRepo = _unitOfWork.GetRepository<InventoryAdjustmentLineItem>();
                var savedAdjustments = adjustmentRepo
                    .AsReadOnly()
                    .Where(x => x.InventoryAdjustment.Reference == reference && x.ProductId == productId)
                    .Select(x => new
                    {
                        Id = x.Id,
                        QuantityAdjusted = x.QuantityAdjusted
                    })
                    .ToList();

                if (savedAdjustments.Count() > 0)
                    throw new ValidationException("Can not have multiple adjustment line.");

                InventoryAdjustmentLineItem adjustment = null;
                bool newAdjustment = false;
                if (savedAdjustments.Count() > 0)
                {
                    // existing adjustment
                    adjustment = new InventoryAdjustmentLineItem { Id = savedAdjustments[0].Id };
                    adjustmentRepo.Attach(adjustment);
                    if (increase)
                    {
                        adjustment.QuantityAdjusted = savedAdjustments[0].QuantityAdjusted + productQuantity;
                    }
                    else if (decrease)
                    {
                        adjustment.QuantityAdjusted = savedAdjustments[0].QuantityAdjusted - productQuantity;
                    }
                }
                else
                {
                    // new adjustment
                    newAdjustment = true;
                    adjustment = new InventoryAdjustmentLineItem();
                    adjustment.InventoryAdjustment = new InventoryAdjustment
                    {
                        AdjustmentDate = DateTimeOffset.UtcNow,
                        Reference = reference,
                        Type = InventoryAdjustmentType.Invoiced
                    };
                }

                adjustment.ProductId = productId;
                adjustment.QuantityAdjusted = productQuantity;
                adjustment.NewQuantityOnHand = newStock;
                adjustment.QuantityAvailable = newStock;
                if (newAdjustment)
                {
                    await adjustmentRepo.AddAsync(adjustment, cancellationToken);
                }

                var _product = new Product { Id = productId };
                productRepo.Attach(_product);
                _product.StockQuantity = newStock;

                result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return result;
        }

    }
}
