using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Integrations.Entities;

namespace Module.Integrations.Domain
{
    public class CreateConnectorCommandHandler : ICommandHandler<CreateConnectorCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateConnectorCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateConnectorCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Connector>();
            var entity = request.Map();
            await repo.AddAsync(entity, cancellationToken);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
