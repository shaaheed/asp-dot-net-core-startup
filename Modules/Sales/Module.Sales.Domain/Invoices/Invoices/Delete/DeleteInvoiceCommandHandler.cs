using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain
{
    public class DeleteInvoiceCommandHandler : ICommandHandler<DeleteInvoiceCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;
        private readonly IContactService _contactService;
        private readonly ILineItemService _lineItemService;

        public DeleteInvoiceCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService,
            IContactService contactService,
            ILineItemService lineItemService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
            _contactService = contactService;
            _lineItemService = lineItemService;
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

            var result = await _lineItemService.DeleteAsync(LineItemType.Sale, invoice.Id, cancellationToken);

            invoiceRepo.Remove(invoice);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            //var allowedStatuses = new List<Status> { Status.Due };
            //if (result > 0 && allowedStatuses.Contains(invoice.Status))
            //{
            //    // increase product stock as invoice has been deleted.
            //    var savedLineItemsHasProduct = savedInvoiceLineItems.Where(x => x.ProductId.HasValue);
            //    foreach (var savedInvoiceLineItem in savedLineItemsHasProduct)
            //    {
            //        result += await _productService.IncreaseStockQuantityWithInventoryAdjustment(invoice.Number, InventoryAdjustmentType.Invoiced, savedInvoiceLineItem.ProductId.Value, savedInvoiceLineItem.LineItemQuantity, cancellationToken);
            //    }
            //}

            decimal receivablesAmount = _invoiceService.GetReceivablesAmount(invoice.CustomerId);
            await _contactService.UpdateBalance(invoice.CustomerId, receivablesAmount, cancellationToken);

            return result;
        }
    }
}
