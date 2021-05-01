using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using System.Collections.Generic;
using Msi.Core;

namespace Module.Sales.Domain
{
    public class DeleteInvoiceCommandHandler : ICommandHandler<DeleteInvoiceCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public DeleteInvoiceCommandHandler(
            IUnitOfWork unitOfWork,
            IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        public async Task<long> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            var invoice = await invoiceRepo.FirstOrDefaultAsync(x => x.Id == request.Id, x => new Invoice
            {
                Id = x.Id,
                Status = x.Status,
                Reference = x.Reference
            }, cancellationToken);

            if (invoice == null)
                throw new ValidationException("Invoice not found.");

            var invoiceLineItemRepo = _unitOfWork.GetRepository<InvoiceLineItem>();
            var savedInvoiceLineItems = await invoiceLineItemRepo.ListAsyncAsReadOnly(x => x.InvoiceId == invoice.Id, x => new
            {
                Id = x.Id,
                LineItemId = x.LineItemId,
                ProductId = x.LineItem.ProductId,
                LineItemQuantity = x.LineItem.Quantity
            }, cancellationToken);

            var lineItemsToBeDeleted = savedInvoiceLineItems.Select(x => new LineItem { Id = x.LineItemId });
            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            lineItemRepo.RemoveRange(lineItemsToBeDeleted);

            var invoiceLineItemsToBeDeleted = savedInvoiceLineItems.Select(x => new InvoiceLineItem { Id = x.Id });
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            invoiceRepo.Remove(invoice);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            var allowedStatuses = new List<Status> { Status.Due };
            if (result > 0 && allowedStatuses.Contains(invoice.Status))
            {
                // increase product stock as invoice has been deleted.
                var savedLineItemsHasProduct = savedInvoiceLineItems.Where(x => x.ProductId.HasValue);
                foreach (var savedInvoiceLineItem in savedLineItemsHasProduct)
                {
                    result += await _productService.IncreaseStockQuantityWithInventoryAdjustment(invoice.Number, InventoryAdjustmentType.Invoiced, savedInvoiceLineItem.ProductId.Value, savedInvoiceLineItem.LineItemQuantity, cancellationToken);
                }
            }
            return result;
        }
    }
}
