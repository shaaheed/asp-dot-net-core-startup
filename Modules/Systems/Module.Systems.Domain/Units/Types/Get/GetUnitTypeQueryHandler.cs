using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Systems.Domain
{
    public class GetUnitTypeQueryHandler : IQueryHandler<GetUnitTypeQuery, UnitTypeDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetUnitTypeQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UnitTypeDto> Handle(GetUnitTypeQuery request, CancellationToken cancellationToken)
        {
            var unitType = await _unitOfWork.GetAsync(x => x.Id == request.Id, UnitTypeDto.Selector(), cancellationToken);
            if (unitType != null)
            {
                var collection = await _unitOfWork.ListAsync(x => x.TypeId == unitType.Id && !x.IsDeleted, UnitDto.Selector(), null, cancellationToken);
                unitType.Units = collection.Items;
            }
            return unitType;
        }
    }
}
