using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using Module.Integrations.Entities;

namespace Module.Integrations.Domain
{
    public class DeleteConnectorCommandHandler : ICommandHandler<DeleteConnectorCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteConnectorCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeleteConnectorCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Connector>();
            var entity = await repo.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
                throw new NotFoundException("Connector not found");

            repo.Remove(entity);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
