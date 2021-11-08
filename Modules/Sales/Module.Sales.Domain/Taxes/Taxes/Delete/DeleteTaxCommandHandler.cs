using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain.Taxes
{
    public class DeleteTaxCommandHandler : ICommandHandler<DeleteTaxCommand, bool>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaxCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteTaxCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Tax>();
            var entity = await repo.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity == null)
                throw new NotFoundException("Tax not found");

            repo.Remove(entity);
            return await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
