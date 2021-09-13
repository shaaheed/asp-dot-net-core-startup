using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain
{
    public class DeleteInventoryAdjustmentCommandHandler : ICommandHandler<DeleteInventoryAdjustmentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteInventoryAdjustmentCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeleteInventoryAdjustmentCommand request, CancellationToken cancellationToken)
        {
            var adjustmentRepo = _unitOfWork.GetRepository<InventoryAdjustment>();
            var adjustment = await adjustmentRepo.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, x => new InventoryAdjustment { Id = x.Id }, cancellationToken);

            if (adjustment == null)
                throw new ValidationException("Adjustment not found");

            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            var lineItems = lineItemRepo
                .Where(x => x.ReferenceId == request.Id && x.Type == ItemTransactionType.Adjustment && !x.IsDeleted)
                .Select(x => new LineItem { Id = x.Id })
                .ToList();
            lineItemRepo.RemoveRange(lineItems);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            adjustmentRepo.Remove(adjustment);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
