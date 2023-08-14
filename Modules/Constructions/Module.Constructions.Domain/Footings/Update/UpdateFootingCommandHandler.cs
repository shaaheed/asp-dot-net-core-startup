using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using Module.Constructions.Entities;
using System;
using System.Linq;
using Module.Systems.Entities;

namespace Module.Constructions.Domain
{
    public class UpdateFootingCommandHandler : ICommandHandler<UpdateFootingCommand, Guid?>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateFootingCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid?> Handle(UpdateFootingCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Footing>();
            var entity = await repo.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException("Footing not found");

            if (request.Values?.Count <= 0)
                throw new ValidationException("Invalid values.");

            var count = request.Values?.Count;
            var distinctCount = request.Values?.DistinctBy(x => x.Type)?.Count();

            if (count != distinctCount)
                throw new ValidationException("Multiple values are not allowed.");

            request.Map(entity);

            var unitValueRepo = _unitOfWork.GetRepository<UnitValue>();
            var footingValueRepo = _unitOfWork.GetRepository<FootingValue>();

            var units = _unitOfWork.GetRepository<Unit>()
                .Where(x => x.TypeId == request.UnitTypeId)
                .Select(x => new
                {
                    Id = x.Id,
                    IsBase = x.IsBaseUnit,
                    ConversionRate = x.ConvertionRate,
                })
                .ToList();

            float volume = 0;

            var requestFootingValueIds = request.Values.Where(x => x.Id.HasValue).Select(x => x.Id.Value);
            var savedFootingValues = footingValueRepo.Where(x => requestFootingValueIds.Contains(x.Id));

            foreach (var x in request.Values)
            {
                var unit = units.Find(x => x.Id == x.Id);
                volume *= unit.IsBase ? x.Value : (x.Value * unit.ConversionRate);

                var savedFootingValue = savedFootingValues.FirstOrDefault(y => x.Id == y.Id);
                if (savedFootingValue == null)
                {
                    var unitValue = new UnitValue { Value = x.Value, UnitId = x.UnitId };
                    await unitValueRepo.AddAsync(unitValue);
                    await _unitOfWork.SaveChangesAsync();

                    var footingValue = new FootingValue { FootingId = entity.Id, Type = x.Type, ValueId = unitValue.Id };
                    await footingValueRepo.AddAsync(footingValue);
                }
                else
                {
                    savedFootingValue.Value.Value = x.Value;
                    savedFootingValue.Value.UnitId = x.UnitId;
                    savedFootingValue.Type = x.Type;
                }
            }

            entity.Volumne = volume;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0 ? request.Id : null;
        }
    }
}
