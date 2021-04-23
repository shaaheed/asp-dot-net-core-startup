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
            var adjustment = await _unitOfWork.GetAsync(x => x.Id == request.Id, InventoryAdjustmentDto.Selector(), cancellationToken);
            if (adjustment != null)
            {
                adjustment.LineItems = _unitOfWork.GetRepository<InventoryAdjustmentLineItem>()
                    .Where(x => x.InventoryAdjustmentId == request.Id)
                    .Select(InventoryAdjustmentLineItemDto.Selector())
                    .ToList();
            }
            return adjustment;
        }
    }
}
