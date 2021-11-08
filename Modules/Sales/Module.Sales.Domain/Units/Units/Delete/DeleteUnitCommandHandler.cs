using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain.Units
{
    public class DeleteUnitCommandHandler : ICommandHandler<DeleteUnitCommand, bool>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteUnitCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Unit>();
            var entity = await repo.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity == null)
                throw new NotFoundException("Unit not found");

            repo.Remove(entity);
            return await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
