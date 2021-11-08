using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain.Units
{
    public class DeleteUnitTypeCommandHandler : ICommandHandler<DeleteUnitTypeCommand, bool>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteUnitTypeCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteUnitTypeCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<UnitType>();
            var entity = await repo.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity == null)
                throw new NotFoundException("Unit type not found");

            repo.Remove(entity);
            return await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
