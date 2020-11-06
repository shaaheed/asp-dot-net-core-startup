using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Bills
{
    public class CreateBillCommandHandler : ICommandHandler<CreateBillCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateBillCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateBillCommand request, CancellationToken cancellationToken)
        {

            var billRepo = _unitOfWork.GetRepository<Bill>();
            var newBill = new Bill
            {
                IssueDate = DateTimeOffset.UtcNow,
                VendorId = request.CustomerId,
                Note = request.Note
            };

            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            var newLineItems = request.Items.Select(x => new LineItem
            {
                Name = x.Name,
                Description = x.Description,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Subtotal = x.Subtotal,
                Total = x.Quantity * x.UnitPrice,
                UnitPrice = x.UnitPrice,
                Note = x.Note
            });

            var billLineItemsRepo = _unitOfWork.GetRepository<BillLineItem>();
            var newBillLineItems = newLineItems.Select(x => new BillLineItem
            {
                Bill = newBill,
                LineItem = x
            });

            newBill.BillLineItems = newBillLineItems.ToList();
            newBill.Calculate();

            await billRepo.AddAsync(newBill, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
