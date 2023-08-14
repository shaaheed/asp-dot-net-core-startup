using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Systems.Entities;

namespace Module.Systems.Domain
{
    public class UpdateUnitCommandHandler : ICommandHandler<UpdateUnitCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateUnitCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.GetRepository<Unit>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if(entity != null)
            {
                request.Map(entity);
            }
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
