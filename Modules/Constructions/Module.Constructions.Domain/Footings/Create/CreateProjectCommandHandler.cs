using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Constructions.Entities;
using System;
using Msi.Core;
using System.Linq;
using Module.Systems.Entities;

namespace Module.Constructions.Domain
{
    public class CreateFootingCommandHandler : CreateCommandHandler<Footing, CreateFootingCommand>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateFootingCommandHandler(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Guid?> Handle(CreateFootingCommand request, CancellationToken cancellationToken)
        {
            if (request.Values?.Count <= 0)
            {
                throw new ValidationException("Invalid values.");
            }

            var count = request.Values?.Count;
            /*var distinctCount = request.Values?.DistinctBy(x => x.Type)?.Count();

            if (count != distinctCount)
            {
                throw new ValidationException("Multiple values are not allowed.");
            }*/

            var entity = request.Map();
            var footing = await base.Handle(entity, cancellationToken);
            if (footing != null)
            {
                var unitValueRepo = _unitOfWork.GetRepository<UnitValue>();
                //var footingValueRepo = _unitOfWork.GetRepository<FootingValue>();

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

                foreach (var x in request.Values)
                {
                    var unit = units.Find(x => x.Id == x.Id);
                    volume *= unit.IsBase ? x.Value : (x.Value * unit.ConversionRate);

                    var unitValue = new UnitValue {
                        Value = x.Value,
                        UnitId = x.UnitId
                    };
                    await unitValueRepo.AddAsync(unitValue);
                    await _unitOfWork.SaveChangesAsync();

                    //var footingValue = new FootingValue {
                    //    FootingId = footing.Value,
                    //    Type = x.Type,
                    //    ValueId = unitValue.Id,
                    //    MultiplyBy = x.MultiplyBy,
                    //};
                    //await footingValueRepo.AddAsync(footingValue);
                }

                //entity.Volumne = volume;
                var result = await _unitOfWork.SaveChangesAsync();
            }

            return footing;
        }
    }
}
