using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using System;
using Msi.Core;
using System.Collections.Generic;

namespace Module.Sales.Domain
{
    public class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;

        public CreateInvoiceCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
        }

        public async Task<long> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {

            var productRepo = _unitOfWork.GetRepository<Product>();
            var requestProductIds = request.Items
                .Where(x => x.ProductId != null)
                .Select(x => x.ProductId.Value)
                .ToList();

            var duplicateProductIds = requestProductIds.Except(requestProductIds.Distinct()).ToList();
            if (duplicateProductIds.Count > 0)
            {
                var firstDuplicateProduct = productRepo
                    .AsReadOnly()
                    .Where(x => x.Id == duplicateProductIds[0])
                    .Select(x => new { Id = x.Id, Name = x.Name })
                    .FirstOrDefault();
                if (firstDuplicateProduct != null)
                    throw new ValidationException($"{firstDuplicateProduct.Name} not found");

                throw new ValidationException($"{firstDuplicateProduct.Name} duplicate entry.");
            }

            var savedProducts = productRepo
                .AsReadOnly()
                .Where(x => requestProductIds.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Quantity = x.StockQuantity,
                    Name = x.Name,
                    IsInventory = x.IsInventory,
                    IsSale = x.IsSale,
                    IsDeleted = x.IsDeleted
                });

            var notFoundProducts = savedProducts
                .Where(x => !requestProductIds.Contains(x.Id))
                .ToList();

            if (notFoundProducts.Count() > 0)
                throw new ValidationException($"{notFoundProducts[0].Name} not found.");

            var inventoryAdjustments = new List<InventoryAdjustmentLineItem>();
            var adjustedProducts = new List<Product>();

            foreach (var product in savedProducts)
            {
                if (!product.IsSale || product.IsDeleted) throw new ValidationException($"{product.Name} is not salable.");

                if (product.IsInventory)
                {
                    var quantityToBuy = request.Items
                        .Where(x => x.ProductId == product.Id)
                        .Select(x => x.Quantity)
                        .Sum();

                    if (product.Quantity < quantityToBuy)
                    {
                        throw new ValidationException($"{product.Name} out of stock.");
                    }
                    if (quantityToBuy > 0)
                    {
                        inventoryAdjustments.Add(new InventoryAdjustmentLineItem
                        {
                            InventoryAdjustment = new InventoryAdjustment
                            {
                                Reference = request.Number,
                                AdjustmentDate = DateTimeOffset.UtcNow,
                                Type = InventoryAdjustmentType.Invoiced
                            },
                            ProductId = product.Id,
                            QuantityAdjusted = quantityToBuy,
                            NewQuantityOnHand = product.Quantity - quantityToBuy,
                            QuantityAvailable = product.Quantity - quantityToBuy
                        });
                        adjustedProducts.Add(new Product
                        {
                            Id = product.Id,
                            StockQuantity = product.Quantity - quantityToBuy
                        });
                    }
                }
            }

            var invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            var newInvoice = request.Map();

            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            var newInvoiceLineItems = request.Items.Select(x => new InvoiceLineItem
            {
                Invoice = newInvoice,
                LineItem = x.Map()
            });

            newInvoice.InvoiceLineItems = newInvoiceLineItems.ToList();
            newInvoice.Calculate();
            _invoiceService.AddPayment(newInvoice);

            await invoiceRepo.AddAsync(newInvoice, cancellationToken);

            if (inventoryAdjustments.Count() > 0)
            {
                await _unitOfWork.GetRepository<InventoryAdjustmentLineItem>().AddRangeAsync(inventoryAdjustments, cancellationToken);
            }
            if (adjustedProducts.Count() > 0)
            {
                productRepo.AttachRange(adjustedProducts);
            }

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
