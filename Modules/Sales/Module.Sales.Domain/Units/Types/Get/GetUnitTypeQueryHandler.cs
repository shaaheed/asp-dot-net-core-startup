using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Units
{
    public class GetUnitTypeQueryHandler : IQueryHandler<GetUnitTypeQuery, UnitTypeDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetUnitTypeQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<UnitTypeDto> Handle(GetUnitTypeQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, UnitTypeDto.Selector(), cancellationToken);
        }
    }
}
