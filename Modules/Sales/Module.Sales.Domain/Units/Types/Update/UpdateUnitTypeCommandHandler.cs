using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Sales.Entities;

namespace Module.Sales.Domain.Units
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
            if(entity != null)
            {
                request.Map(entity);
            }
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
