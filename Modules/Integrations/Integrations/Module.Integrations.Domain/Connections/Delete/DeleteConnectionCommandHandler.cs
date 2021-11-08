using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using Module.Integrations.Entities;

namespace Module.Integrations.Domain
{
    public class DeleteConnectionCommandHandler : ICommandHandler<DeleteConnectionCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteConnectionCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeleteConnectionCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Connection>();
            var entity = await repo.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
                throw new NotFoundException("Connection not found");

            repo.Remove(entity);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
