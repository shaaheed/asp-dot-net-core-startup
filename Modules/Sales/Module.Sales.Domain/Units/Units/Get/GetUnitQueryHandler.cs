using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Units
{
    public class GetUnitQueryHandler : IQueryHandler<GetUnitQuery, UnitDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetUnitQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<UnitDto> Handle(GetUnitQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, UnitDto.Selector(), cancellationToken);
        }
    }
}
