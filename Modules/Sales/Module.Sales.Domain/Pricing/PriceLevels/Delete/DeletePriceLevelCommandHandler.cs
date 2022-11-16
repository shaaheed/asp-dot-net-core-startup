using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain
{
    public class DeletePriceLevelCommandHandler : ICommandHandler<DeletePriceLevelCommand, bool>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeletePriceLevelCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeletePriceLevelCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<PriceLevel>();
            var entity = await repo.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity == null)
                throw new NotFoundException("Price level not found");

            repo.Remove(entity);
            return await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
