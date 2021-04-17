using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain
{
    public class UpdateInvoiceCommandHandler : ICommandHandler<UpdateInvoiceCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;

        public UpdateInvoiceCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
        }

        public async Task<long> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {

            var invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            var invoice = await invoiceRepo.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (invoice == null)
                throw new NotFoundException("Invoice not found");

            var productRepo = _unitOfWork.GetRepository<Product>();
            var requestProductIds = request.Items
                .Where(x => x.Id != null)
                .Select(x => x.Id.Value)
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
                    Stock = x.StockQuantity,
                    IsInventory = x.IsInventory,
                    IsSale = x.IsSale,
                    IsDeleted = x.IsDeleted
                });

            var notFoundProducts = savedProducts
                .Where(x => !requestProductIds.Contains(x.Id))
                .ToList();

            if (notFoundProducts.Count() > 0)
                throw new ValidationException($"{notFoundProducts[0].Name} not found.");

            var invoiceLineItemRepo = _unitOfWork.GetRepository<InvoiceLineItem>();
            var invoiceLineItems = new List<InvoiceLineItem>();

            var savedInvoiceLineItems = invoiceLineItemRepo
                .AsReadOnly()
                .Where(x => x.InvoiceId == invoice.Id)
                .Select(x => new
                {
                    Id = x.Id,
                    LineItemId = x.LineItemId,
                    ProductId = x.LineItem.ProductId,
                    ProductName = x.LineItem.Product.Name,
                    LineItemQuantity = x.LineItem.Quantity
                })
                .ToList();

            var inventoryAdjustmentLineItemRepo = _unitOfWork.GetRepository<InventoryAdjustmentLineItem>();
            var inventoryAdjustments = new List<InventoryAdjustmentLineItem>();
            var adjustedProducts = new List<Product>();

            foreach (var requestItem in request.Items)
            {
                var invoiceLineItem = new InvoiceLineItem();
                if (requestItem.Id.HasValue)
                {
                    var savedItem = savedInvoiceLineItems.FirstOrDefault(x => x.Id == requestItem.Id);

                    if (savedItem == null)
                        throw new ValidationException("Line item not found");

                    await _invoiceService.CreateOrUpdateInvoiceLineItem(requestItem, savedItem.LineItemId, cancellationToken);

                    // invoice line item product changed
                    if (requestItem.ProductId.HasValue && savedItem.ProductId.HasValue && requestItem.ProductId.Value != savedItem.ProductId.Value)
                    {
                        // increase saved invoice line item product stock
                        // because it is removed from UI invoice
                        await _invoiceService.CreateOrUpdateInventoryAdjustment(
                            invoice.Number,
                            savedItem.ProductId.Value,
                            requestItem.Quantity,
                            true,
                            false,
                            cancellationToken);

                        // decrease newly added invoice line item product stock
                        // becasue it is added UI in invoice
                        await _invoiceService.CreateOrUpdateInventoryAdjustment(
                            invoice.Number,
                            requestItem.ProductId.Value,
                            requestItem.Quantity,
                            false,
                            true,
                            cancellationToken);
                    }
                    // invoice line item product not changed but quantiy may changed
                    else if (requestItem.ProductId.HasValue && savedItem.ProductId.HasValue && requestItem.ProductId.Value == savedItem.ProductId.Value)
                    {
                        var savedProduct = productRepo
                            .Where(x => x.Id == savedItem.Id)
                            .Select(x => new
                            {
                                Id = x.Id,
                                StockQuantity = x.StockQuantity
                            })
                            .FirstOrDefault();

                        if (savedProduct == null)
                            throw new ValidationException("Product not found");

                        if (requestItem.Quantity > savedProduct.StockQuantity)
                        {
                            // more quantity added
                            var adjustedStock = requestItem.Quantity - savedProduct.StockQuantity;
                            await _invoiceService.CreateOrUpdateInventoryAdjustment(
                                invoice.Number,
                                requestItem.ProductId.Value,
                                adjustedStock,
                                true,
                                false,
                                cancellationToken);
                        }
                        else if (savedProduct.StockQuantity < requestItem.Quantity)
                        {
                            // quantity reduced
                            var adjustedStock = savedProduct.StockQuantity - requestItem.Quantity;
                            await _invoiceService.CreateOrUpdateInventoryAdjustment(
                                invoice.Number,
                                requestItem.ProductId.Value,
                                adjustedStock,
                                false,
                                true,
                                cancellationToken);
                        }
                    }
                    else if (requestItem.ProductId.HasValue && !savedItem.ProductId.HasValue)
                    {
                        // product added to invoice line item
                        // product stock need to reduce
                        await _invoiceService.CreateOrUpdateInventoryAdjustment(
                            invoice.Number,
                            requestItem.ProductId.Value,
                            requestItem.Quantity,
                            false,
                            true,
                            cancellationToken);
                    }
                    else if (!requestItem.ProductId.HasValue && savedItem.ProductId.HasValue)
                    {
                        // product removed from invoice line item
                        // product stock need to increase
                        await _invoiceService.CreateOrUpdateInventoryAdjustment(
                            invoice.Number,
                            savedItem.ProductId.Value,
                            savedItem.LineItemQuantity,
                            true,
                            false,
                            cancellationToken);
                    }

                }
                else
                {
                    await _invoiceService.CreateOrUpdateInvoiceLineItem(requestItem, null, cancellationToken);
                }
            }

            var deletedInvoiceLineItems = new List<InvoiceLineItem>();
            var deletedLineItems = new List<LineItem>();
            var modifiedLineItems = new List<Guid>();
            foreach (var savedInvoiceLineItem in savedInvoiceLineItems)
            {
                var requestModifiedItemIds = new List<Guid>();
                if (!requestModifiedItemIds.Contains(savedInvoiceLineItem.Id))
                {
                    // saved items not provided in request means it is deleted
                    deletedInvoiceLineItems.Add(new InvoiceLineItem { Id = savedInvoiceLineItem.Id });
                    deletedLineItems.Add(new LineItem { Id = savedInvoiceLineItem.LineItemId });
                }
                else
                {
                    var requestModifiedItem = request.Items
                        .Where(x => x.Id == savedInvoiceLineItem.Id)
                        .Select(x =>
                        {
                            var lineItem = x.Map();
                            lineItem.Id = savedInvoiceLineItem.Id;
                            return x;
                        });
                    modifiedLineItems.Add(savedInvoiceLineItem.LineItemId);
                }
            }

            var invoiceLineItemsRepo = _unitOfWork.GetRepository<InvoiceLineItem>();
            var invoiceLineItemsToBeRemoved = invoiceLineItemsRepo.Where(x => x.InvoiceId == request.Id);
            var lineItemsToBeRemoved = invoiceLineItemsToBeRemoved.Select(x => x.LineItem);

            invoiceLineItemsRepo.RemoveRange(invoiceLineItemsToBeRemoved);
            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            lineItemRepo.RemoveRange(lineItemsToBeRemoved);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var newLineItems = request.Items.Select(x => new LineItem
            {
                Name = x.Name,
                Description = x.Description,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Subtotal = x.Subtotal,
                Total = (decimal)x.Quantity * x.UnitPrice,
                UnitPrice = x.UnitPrice,
                UnitId = x.UnitId,
                Note = x.Note
            });

            var newInvoiceLineItems = newLineItems.Select(x => new InvoiceLineItem
            {
                Invoice = invoice,
                LineItem = x
            });

            invoice.InvoiceLineItems = newInvoiceLineItems.ToList();
            invoice.Calculate();

            invoice.AmountDue = 0;
            _invoiceService.AddPayment(invoice);

            if (false /*invoicePaymentAmount > invoice.GrandTotal*/)
            {
                //Over paid.
                //TODO: Create credit note
            }

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
