using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Products
{
    public class GetUnitTypesQueryHandler : IQueryHandler<GetUnitTypesQuery, PagedCollection<UnitTypeDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetUnitTypesQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<UnitTypeDto>> Handle(GetUnitTypesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(UnitTypeDto.Selector(), request.PagingOptions, request.SearchOptions, cancellationToken);
        }
    }
}
