using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Sales.Entities;
using System.Linq;

namespace Module.Sales.Domain
{
    public class GetInventoryAdjustmentQueryHandler : IQueryHandler<GetInventoryAdjustmentQuery, InventoryAdjustmentDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetInventoryAdjustmentQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<InventoryAdjustmentDto> Handle(GetInventoryAdjustmentQuery request, CancellationToken cancellationToken)
        {
            var adjustment = await _unitOfWork.GetAsync(x => x.Id == request.Id && !x.IsDeleted, InventoryAdjustmentDto.Selector(), cancellationToken);
            if (adjustment != null)
            {
                adjustment.LineItems = _unitOfWork.GetRepository<LineItem>()
                    .Where(x => x.ReferenceId == request.Id && x.Type == ItemTransactionType.Adjustment && !x.IsDeleted)
                    .Select(InventoryAdjustmentLineItemDto.Selector())
                    .ToList();
            }
            return adjustment;
        }
    }
}
