using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Units
{
    public class GetUnitsQueryHandler : IQueryHandler<GetUnitsQuery, PagedCollection<UnitListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetUnitsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<UnitListItemDto>> Handle(GetUnitsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(UnitListItemDto.Selector(), request.PagingOptions, request.SearchOptions, cancellationToken);
        }
    }
}
