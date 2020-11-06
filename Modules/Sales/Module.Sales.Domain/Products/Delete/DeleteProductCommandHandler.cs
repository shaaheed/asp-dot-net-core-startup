using Msi.Mediator.Abstractions;
using Core.Infrastructure.Exceptions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Products
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Product>();
            var productToBeDeleted = await repo.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (productToBeDeleted == null)
                throw new NotFoundException("Product not found");

            repo.Remove(productToBeDeleted);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
