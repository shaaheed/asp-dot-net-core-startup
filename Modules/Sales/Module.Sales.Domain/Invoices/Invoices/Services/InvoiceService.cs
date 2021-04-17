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
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddPayment(Guid invoiceId)
        {
            var invoice = _unitOfWork.GetRepository<Invoice>()
                .Where(x => x.Id == invoiceId && !x.IsDeleted)
                .FirstOrDefault();
            AddPayment(invoice);
        }

        public void AddPayment(Invoice invoice)
        {
            if (invoice != null)
            {
                var paymentsAmount = GetInvoicePaymentsAmount(invoice.Id);
                invoice.AddPayment(paymentsAmount);
            }
        }

        public decimal GetInvoicePaymentsAmount(Guid invoiceId)
        {
            var paymentAmount = _unitOfWork.GetRepository<InvoicePayment>()
                .AsReadOnly()
                .Where(x => x.InvoiceId == invoiceId && !x.Invoice.IsDeleted)
                .Select(x => x.Payment.Amount)
                .Sum();
            return paymentAmount;
        }

        public string GetNextInvoiceNumber()
        {
            var count = _unitOfWork.GetRepository<Invoice>()
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => x.Id)
                .LongCount();

            return $"INV-{count + 1}";
        }

        public async Task<int> CreateOrUpdateInvoiceLineItem(
            InvoiceLineItemRequestDto request,
            Guid? lineItemId,
            CancellationToken cancellationToken = default)
        {
            var lineItem = request.Map();
            if (lineItemId.HasValue)
            {
                lineItem.Id = lineItemId.Value;
            }

            var invoiceLineItem = new InvoiceLineItem
            {
                LineItem = lineItem
            };
            if (request.Id.HasValue)
            {
                invoiceLineItem.Id = request.Id.Value;
            }
            _unitOfWork.GetRepository<InvoiceLineItem>()
                .AttachRange(new List<InvoiceLineItem> { invoiceLineItem });
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }

        public async Task<int> CreateOrUpdateInventoryAdjustment(
            string invoiceNumber,
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
                    .Where(x => x.InventoryAdjustment.Reference == invoiceNumber && x.ProductId == productId)
                    .Select(x => new
                    {
                        Id = x.Id,
                        QuantityAdjusted = x.QuantityAdjusted
                    })
                    .ToList();

                if (savedAdjustments.Count() > 0)
                    throw new ValidationException("Can not have multiple adjustment line.");

                var adjustment = new InventoryAdjustmentLineItem();
                if (savedAdjustments.Count() > 0)
                {
                    // existing adjustment
                    adjustment.Id = savedAdjustments[0].Id;
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
                    adjustment.InventoryAdjustment = new InventoryAdjustment
                    {
                        AdjustmentDate = DateTimeOffset.UtcNow,
                        Reference = invoiceNumber,
                        Type = InventoryAdjustmentType.Invoiced
                    };
                }

                adjustment.ProductId = productId;
                adjustment.QuantityAdjusted = productQuantity;
                adjustment.NewQuantityOnHand = newStock;
                adjustment.QuantityAvailable = newStock;
                adjustmentRepo.AttachRange(new List<InventoryAdjustmentLineItem> { adjustment });

                productRepo.AttachRange(new List<Product> {
                new Product {
                    Id = productId,
                    StockQuantity = newStock
                }
            });
                result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return result;
        }

    }
}
