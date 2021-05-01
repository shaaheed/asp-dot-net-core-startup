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
    public class DeleteBillCommandHandler : ICommandHandler<DeleteBillCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public DeleteBillCommandHandler(
            IUnitOfWork unitOfWork,
            IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        public async Task<long> Handle(DeleteBillCommand request, CancellationToken cancellationToken)
        {
            var billRepo = _unitOfWork.GetRepository<Bill>();
            var bill = await billRepo.FirstOrDefaultAsync(x => x.Id == request.Id, x => new Bill
            {
                Id = x.Id,
                Status = x.Status,
                Reference = x.Reference
            }, cancellationToken);

            if (bill == null)
                throw new ValidationException("Bill not found.");

            var billLineItemRepo = _unitOfWork.GetRepository<BillLineItem>();
            var savedBillLineItems = await billLineItemRepo.ListAsyncAsReadOnly(x => x.BillId == bill.Id, x => new
            {
                Id = x.Id,
                LineItemId = x.LineItemId,
                ProductId = x.LineItem.ProductId,
                LineItemQuantity = x.LineItem.Quantity
            }, cancellationToken);

            var lineItemsToBeDeleted = savedBillLineItems.Select(x => new LineItem { Id = x.LineItemId });
            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            lineItemRepo.RemoveRange(lineItemsToBeDeleted);

            var invoiceLineItemsToBeDeleted = savedBillLineItems.Select(x => new InvoiceLineItem { Id = x.Id });
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            billRepo.Remove(bill);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            var allowedStatuses = new List<Status> { Status.Due };
            if (result > 0 && allowedStatuses.Contains(bill.Status))
            {
                // increase product stock as bill has been deleted.
                var savedLineItemsHasProduct = savedBillLineItems.Where(x => x.ProductId.HasValue);
                foreach (var savedBillLineItem in savedLineItemsHasProduct)
                {
                    result += await _productService.IncreaseStockQuantityWithInventoryAdjustment(bill.Number, InventoryAdjustmentType.Billed, savedBillLineItem.ProductId.Value, savedBillLineItem.LineItemQuantity, cancellationToken);
                }
            }
            return result;
        }
    }
}
