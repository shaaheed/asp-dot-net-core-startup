using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using Module.Integrations.Entities;

namespace Module.Integrations.Domain
{
    public class UpdateConnectorCommandHandler : ICommandHandler<UpdateConnectorCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateConnectorCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateConnectorCommand request, CancellationToken cancellationToken)
        {
            // TODO: handle contact person etc
            var entity = await _unitOfWork.GetRepository<Connector>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
                throw new NotFoundException("Connector not found");

            request.Map(entity);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
