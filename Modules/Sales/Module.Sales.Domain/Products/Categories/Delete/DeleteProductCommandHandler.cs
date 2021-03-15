using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain.Products
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Category>();
            var entity = await repo.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity == null)
                throw new NotFoundException("Product category not found");

            repo.Remove(entity);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
