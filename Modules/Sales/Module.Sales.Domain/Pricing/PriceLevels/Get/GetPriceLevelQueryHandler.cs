using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class GetPriceLevelQueryHandler : IQueryHandler<GetPriceLevelQuery, PriceLevelDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetPriceLevelQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PriceLevelDto> Handle(GetPriceLevelQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, PriceLevelDto.Selector(), cancellationToken);
        }
    }
}
