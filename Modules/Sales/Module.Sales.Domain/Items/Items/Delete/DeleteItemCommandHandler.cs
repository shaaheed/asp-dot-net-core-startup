using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain.Items
{
    public class DeleteItemCommandHandler : ICommandHandler<DeleteItemCommand, bool>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteItemCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Item>();
            var productToBeDeleted = await repo.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (productToBeDeleted == null)
                throw new NotFoundException("Item not found");

            repo.Remove(productToBeDeleted);
            return await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
