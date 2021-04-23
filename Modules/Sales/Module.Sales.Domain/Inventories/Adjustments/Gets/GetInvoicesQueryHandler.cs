using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain
{
    public class GetInventoryAdjustmentsQueryHandler : IQueryHandler<GetInventoryAdjustmentsQuery, PagedCollection<InventoryAdjustmentListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetInventoryAdjustmentsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<InventoryAdjustmentListItemDto>> Handle(GetInventoryAdjustmentsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(InventoryAdjustmentListItemDto.Selector(), request.PagingOptions, request.SearchOptions, cancellationToken);
        }
    }
}
