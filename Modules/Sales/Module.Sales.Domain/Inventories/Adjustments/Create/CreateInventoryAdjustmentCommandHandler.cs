using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using System.Collections.Generic;

namespace Module.Sales.Domain
{
    public class CreateInventoryAdjustmentCommandHandler : ICommandHandler<CreateInventoryAdjustmentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public CreateInventoryAdjustmentCommandHandler(
            IUnitOfWork unitOfWork,
            IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        public async Task<long> Handle(CreateInventoryAdjustmentCommand request, CancellationToken cancellationToken)
        {
            var newAdjustment = request.Map();
            await _unitOfWork.GetRepository<InventoryAdjustment>().AddAsync(newAdjustment);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var productRepo = _unitOfWork.GetRepository<Product>();
            var requestProductIds = request.LineItems
                .Select(x => x.ProductId)
                .ToList();

            await _productService.CheckDuplicate(requestProductIds, cancellationToken);

            var savedProducts = await productRepo
                .ListAsyncAsReadOnly(x => requestProductIds.Contains(x.Id), x => new
                {
                    Id = x.Id,
                    Quantity = x.StockQuantity,
                    Name = x.Name,
                    IsInventory = x.IsInventory,
                    IsSale = x.IsSale,
                    IsDeleted = x.IsDeleted
                }, cancellationToken);

            var notFoundProducts = savedProducts
                .Where(x => !requestProductIds.Contains(x.Id))
                .ToList();

            if (notFoundProducts.Count() > 0)
                throw new ValidationException($"{notFoundProducts[0].Name} not found.");

            var adjustmentLines = new List<LineItem>();

            foreach (var product in savedProducts)
            {
                if (!product.IsSale || product.IsDeleted) throw new ValidationException($"{product.Name} is not salable.");

                if (product.IsInventory)
                {
                    var quantity = request.LineItems
                        .Where(x => x.ProductId == product.Id)
                        .Select(x => x.Quantity)
                        .Sum();

                    if (product.Quantity < quantity)
                    {
                        throw new ValidationException($"{product.Name} out of stock.");
                    }
                    if (quantity > 0)
                    {
                        adjustmentLines.Add(new LineItem
                        {
                            ProductId = product.Id,
                            Quantity = quantity,
                            DocumentId = newAdjustment.Id,
                            TransactionType = LineTransactionType.Adjustment
                        });
                        var _product = new Product { Id = product.Id };
                        productRepo.Attach(_product);
                        _product.StockQuantity = product.Quantity + quantity;
                    }
                }
            }

            await _unitOfWork.GetRepository<LineItem>().AddRangeAsync(adjustmentLines, cancellationToken);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
