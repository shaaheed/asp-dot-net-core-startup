using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Integrations.Entities;

namespace Module.Integrations.Domain
{
    public class CreateConnectionCommandHandler : ICommandHandler<CreateConnectionCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateConnectionCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateConnectionCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Connection>();
            var entity = request.Map();
            await repo.AddAsync(entity, cancellationToken);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
