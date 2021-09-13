using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain
{
    public class DeleteBillCommandHandler : ICommandHandler<DeleteBillCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillService _billService;
        private readonly IContactService _contactService;

        public DeleteBillCommandHandler(
            IUnitOfWork unitOfWork,
            IBillService billService,
            IContactService contactService)
        {
            _unitOfWork = unitOfWork;
            _billService = billService;
            _contactService = contactService;
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

            var result = await _billService.DeleteLineItemAsync(ItemTransactionType.Purchase, bill.Id, cancellationToken);

            billRepo.Remove(bill);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            //var allowedStatuses = new List<Status> { Status.Due };
            //if (result > 0 && allowedStatuses.Contains(bill.Status))
            //{
            //    // decrease product stock as bill has been deleted.
            //    var savedLineItemsHasProduct = savedBillLineItems.Where(x => x.ProductId.HasValue);
            //    foreach (var savedBillLineItem in savedLineItemsHasProduct)
            //    {
            //        result += await _productService.DecreaseStockQuantityWithInventoryAdjustment(bill.Number, InventoryAdjustmentType.Billed, savedBillLineItem.ProductId.Value, savedBillLineItem.LineItemQuantity, cancellationToken);
            //    }
            //}

            decimal payablesAmount = _billService.GetPayablesAmount(bill.SupplierId);
            await _contactService.UpdateBalance(bill.SupplierId, payablesAmount, cancellationToken);

            return result;
        }
    }
}
