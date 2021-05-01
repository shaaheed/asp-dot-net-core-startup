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
    public class UpdateInvoiceCommandHandler : ICommandHandler<UpdateInvoiceCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;
        private readonly IProductService _productService;

        public UpdateInvoiceCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService,
            IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
            _productService = productService;
        }

        public async Task<long> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {

            var invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            var invoice = await invoiceRepo.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (invoice == null)
                throw new NotFoundException("Invoice not found");

            var productRepo = _unitOfWork.GetRepository<Product>();
            var requestProductIds = request.Items
                .Where(x => x.ProductId != null)
                .Select(x => x.ProductId.Value)
                .ToList();
            await _productService.CheckDuplicate(requestProductIds, cancellationToken);

            var savedProducts = await _productService.GetSavedProducts(requestProductIds, cancellationToken);
            _productService.CheckProductNotFound(savedProducts);

            var invoiceLineItemsRepo = _unitOfWork.GetRepository<InvoiceLineItem>();
            var invoiceLineItems = new List<InvoiceLineItem>();

            var savedInvoiceLineItems = await invoiceLineItemsRepo
                .ListAsyncAsReadOnly(x => x.InvoiceId == invoice.Id, x => new
                {
                    Id = x.Id,
                    LineItemId = x.LineItemId,
                    ProductId = x.LineItem.ProductId,
                    ProductName = x.LineItem.Product.Name,
                    LineItemQuantity = x.LineItem.Quantity
                }, cancellationToken);

            var inventoryAdjustmentLineItemRepo = _unitOfWork.GetRepository<InventoryAdjustmentLineItem>();
            var inventoryAdjustments = new List<InventoryAdjustmentLineItem>();
            var adjustedProducts = new List<Product>();

            var result = 0;
            foreach (var requestLineItem in request.Items)
            {
                if (requestLineItem.Id.HasValue)
                {
                    // update
                    var savedLineItem = savedInvoiceLineItems.FirstOrDefault(x => x.Id == requestLineItem.Id);

                    if (savedLineItem == null)
                        throw new ValidationException("Line item not found");

                    result += await _invoiceService.CreateOrUpdateInvoiceLineItem(requestLineItem, invoice.Id, savedLineItem.LineItemId, cancellationToken);

                    // invoice line item product changed
                    if (requestLineItem.ProductId.HasValue && savedLineItem.ProductId.HasValue && requestLineItem.ProductId.Value != savedLineItem.ProductId.Value)
                    {
                        // reducing product stock as new product is added to invoice line item
                        result += await _productService.DecreaseStockQuantityWithInventoryAdjustment(invoice.Number, InventoryAdjustmentType.Invoiced, requestLineItem.ProductId.Value, requestLineItem.Quantity, cancellationToken);

                        // increasing product stock as product is removed from invoice line item
                        result += await _productService.IncreaseStockQuantityWithInventoryAdjustment(invoice.Number, InventoryAdjustmentType.Invoiced, savedLineItem.ProductId.Value, savedLineItem.LineItemQuantity, cancellationToken);
                    }

                    // invoice line item product not changed but quantiy may changed
                    else if (requestLineItem.ProductId.HasValue && savedLineItem.ProductId.HasValue && requestLineItem.ProductId.Value == savedLineItem.ProductId.Value)
                    {
                        if (requestLineItem.Quantity > savedLineItem.LineItemQuantity)
                        {
                            // product stock quantity will be  decrease
                            var quantityToBeDecrease = requestLineItem.Quantity - savedLineItem.LineItemQuantity;
                            result += await _productService.DecreaseStockQuantityWithInventoryAdjustment(invoice.Number, InventoryAdjustmentType.Invoiced, requestLineItem.ProductId.Value, quantityToBeDecrease, cancellationToken);
                        }
                        else if (requestLineItem.Quantity < savedLineItem.LineItemQuantity)
                        {
                            // product stock quantity will be increase
                            var quantityToBeIncrease = savedLineItem.LineItemQuantity - requestLineItem.Quantity;
                            result += await _productService.IncreaseStockQuantityWithInventoryAdjustment(invoice.Number, InventoryAdjustmentType.Invoiced, requestLineItem.ProductId.Value, quantityToBeIncrease, cancellationToken);
                        }
                    }

                    else if (requestLineItem.ProductId.HasValue && !savedLineItem.ProductId.HasValue)
                    {
                        // new product added to invoice line item
                        // product stock quantity will be decrease
                        result += await _productService.DecreaseStockQuantityWithInventoryAdjustment(invoice.Number, InventoryAdjustmentType.Invoiced, requestLineItem.ProductId.Value, requestLineItem.Quantity, cancellationToken);
                    }

                    else if (!requestLineItem.ProductId.HasValue && savedLineItem.ProductId.HasValue)
                    {
                        // product removed from invoice line item
                        // product stock quantity will be increase
                        result += await _productService.IncreaseStockQuantityWithInventoryAdjustment(invoice.Number, InventoryAdjustmentType.Invoiced, savedLineItem.ProductId.Value, savedLineItem.LineItemQuantity, cancellationToken);
                    }
                }
                else
                {
                    if (requestLineItem.ProductId.HasValue)
                    {
                        await _productService.CheckProductSelable(requestLineItem.ProductId, requestLineItem.Name, cancellationToken);

                        result += await _productService.DecreaseStockQuantityWithInventoryAdjustment(invoice.Number, InventoryAdjustmentType.Invoiced, requestLineItem.ProductId.Value, requestLineItem.Quantity, cancellationToken);
                    }

                    result += await _invoiceService.CreateOrUpdateInvoiceLineItem(requestLineItem, invoice.Id, null, cancellationToken);
                }
            }

            var deletedInvoiceLineItems = new List<InvoiceLineItem>();
            var deletedLineItems = new List<LineItem>();
            foreach (var savedLineItem in savedInvoiceLineItems)
            {
                var requestItem = request.Items.FirstOrDefault(x => x.Id == savedLineItem.Id);
                if (requestItem == null)
                {
                    // delete saved item
                    deletedInvoiceLineItems.Add(new InvoiceLineItem { Id = savedLineItem.Id });
                    deletedLineItems.Add(new LineItem { Id = savedLineItem.LineItemId });

                    // increase product stock as product line item is deleted
                    if (savedLineItem.ProductId.HasValue)
                    {
                        await _productService.IncreaseStockQuantityWithInventoryAdjustment(invoice.Number, InventoryAdjustmentType.Invoiced, savedLineItem.ProductId.Value, savedLineItem.LineItemQuantity, cancellationToken);
                    }
                }
            }

            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            lineItemRepo.RemoveRange(deletedLineItems);
            invoiceLineItemsRepo.RemoveRange(deletedInvoiceLineItems);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            _invoiceService.Calculate(invoice);
            _invoiceService.AddPayment(invoice);

            if (false /*invoicePaymentAmount > invoice.GrandTotal*/)
            {
                //Over paid.
                //TODO: Create credit note
            }

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
