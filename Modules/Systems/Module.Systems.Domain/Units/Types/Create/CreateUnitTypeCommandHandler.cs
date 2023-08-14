using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using System.Linq;
using Module.Systems.Entities;

namespace Module.Systems.Domain
{
    public class CreateUnitTypeCommandHandler : ICommandHandler<CreateUnitTypeCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateUnitTypeCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateUnitTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Map();
            var repo = _unitOfWork.GetRepository<UnitType>();
            await repo.AddAsync(entity, cancellationToken);
            long result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result > 0 && request.Units.Count > 0)
            {
                var untis = request.Units.Select(x => {
                    var unit = x.Map();
                    unit.TypeId = entity.Id;
                    return unit;
                });
                await _unitOfWork.GetRepository<Unit>().AddRangeAsync(untis);
                result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}
