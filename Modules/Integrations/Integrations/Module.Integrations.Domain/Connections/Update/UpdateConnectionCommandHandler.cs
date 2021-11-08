using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using Module.Integrations.Entities;

namespace Module.Integrations.Domain
{
    public class UpdateConnectionCommandHandler : ICommandHandler<UpdateConnectionCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateConnectionCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateConnectionCommand request, CancellationToken cancellationToken)
        {
            // TODO: handle contact person etc
            var entity = await _unitOfWork.GetRepository<Connection>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
                throw new NotFoundException("Connection not found");

            request.Map(entity);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
