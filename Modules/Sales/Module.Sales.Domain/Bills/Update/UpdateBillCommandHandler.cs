using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain.Bills
{
    public class UpdateBillCommandHandler : ICommandHandler<UpdateBillCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateBillCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateBillCommand request, CancellationToken cancellationToken)
        {

            var billRepo = _unitOfWork.GetRepository<Bill>();
            var bill = await billRepo.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (bill == null)
                throw new NotFoundException("Bill not found");

            bill.VendorId = request.VendorId;
            bill.Note = request.Note;

            var billLineItemsRepo = _unitOfWork.GetRepository<BillLineItem>();
            var billLineItemsToBeRemoved = billLineItemsRepo.Where(x => x.BillId == request.Id);
            var lineItemsToBeRemoved = billLineItemsToBeRemoved.Select(x => x.LineItem);

            billLineItemsRepo.RemoveRange(billLineItemsToBeRemoved);
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
                Note = x.Note
            });

            var newBillLineItems = newLineItems.Select(x => new BillLineItem
            {
                Bill = bill,
                LineItem = x
            });

            bill.BillLineItems = newBillLineItems.ToList();
            bill.Calculate();

            bill.AmountDue = 0;
            //var billPaymentAmount = _unitOfWork.GetRepository<BillPayment>()
            //    .Where(x => x.BillId == bill.Id)
            //    .Select(x => x.Payment.Amount)
            //    .Sum();

            //bill.AddPayment(billPaymentAmount);
            
            if (false /*billPaymentAmount > bill.GrandTotal*/)
            {
                // Over paid.
                // TODO: Create credit note
            }

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
