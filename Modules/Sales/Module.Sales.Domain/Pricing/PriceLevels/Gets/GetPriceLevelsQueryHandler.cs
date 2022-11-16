using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain
{
    public class GetPriceLevelsQueryHandler : IQueryHandler<GetPriceLevelsQuery, PagedCollection<PriceLevelDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetPriceLevelsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedCollection<PriceLevelDto>> Handle(GetPriceLevelsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ListAsync(PriceLevelDto.Selector(), request.FilterOptions, cancellationToken);
            return result;
        }
    }
}
