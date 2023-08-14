using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Module.Systems.Entities;

namespace Module.Systems.Domain
{
    public class UpdateUnitTypeCommandHandler : ICommandHandler<UpdateUnitTypeCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateUnitTypeCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateUnitTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.GetRepository<UnitType>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity != null)
            {
                request.Map(entity);
            }
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var unitIds = request.Units.Where(x => x.Id != null).Select(x => x.Id.Value);
            var unitRepo = _unitOfWork.GetRepository<Unit>();
            var savedUnits = unitRepo.Where(x => unitIds.Contains(x.Id)).ToList();

            var newUnits = new List<Unit>();
            foreach (var requestUnit in request.Units)
            {
                var savedUnit = savedUnits.FirstOrDefault(x => x.Id == requestUnit.Id);
                if (savedUnit == null)
                {
                    var newUnit = requestUnit.Map();
                    newUnit.TypeId = request.Id;
                    newUnits.Add(newUnit);
                }
                else
                {
                    requestUnit.Map(savedUnit);
                    savedUnit.TypeId = request.Id;
                }
            }

            if (newUnits.Count > 0)
            {
                await unitRepo.AddRangeAsync(newUnits);
            }
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
