using Core.Infrastructure.Commands;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.Bills
{
    public class DeleteBillCommandHandler : ICommandHandler<DeleteBillCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteBillCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeleteBillCommand request, CancellationToken cancellationToken)
        {
            var billRepo = _unitOfWork.GetRepository<Invoice>();
            var bill = await billRepo.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var billLineItemRepo = _unitOfWork.GetRepository<BillLineItem>();
            var billLineItemsToBeDeleted = billLineItemRepo
                .Where(x => x.BillId == request.Id);
            var lineItemsToBeDeleted = billLineItemsToBeDeleted.Select(x => x.LineItem);

            _unitOfWork.GetRepository<LineItem>().RemoveRange(lineItemsToBeDeleted);
            billLineItemRepo.RemoveRange(billLineItemsToBeDeleted);
            billRepo.Remove(bill);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
