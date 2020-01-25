using Core.Infrastructure.Commands;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.Products
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = CreateProductCommand.To(request);
            var repo = _unitOfWork.GetRepository<Product>();
            await repo.AddAsync(newProduct, cancellationToken);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
