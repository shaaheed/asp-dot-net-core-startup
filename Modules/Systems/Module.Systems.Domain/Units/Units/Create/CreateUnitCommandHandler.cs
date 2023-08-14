using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Systems.Entities;

namespace Module.Systems.Domain
{
    public class CreateUnitCommandHandler : ICommandHandler<CreateUnitCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateUnitCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Map();
            var repo = _unitOfWork.GetRepository<Unit>();
            await repo.AddAsync(entity, cancellationToken);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
