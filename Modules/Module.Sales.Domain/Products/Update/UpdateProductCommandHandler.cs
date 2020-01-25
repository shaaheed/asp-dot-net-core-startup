using Core.Infrastructure.Commands;
using Msi.Extensions.Persistence.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain.Products
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetRepository<Entities.Product>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if(product != null)
            {
                product.Name = request.Name;
                product.Code = request.Code;
                product.Description = request.Description;
                product.Price = request.Price;
                product.IsBuy = request.IsBuy;
                product.IsSale = request.IsSale;
                var newEvent = new ProductUpdatedEvent();
                newEvent.GenerateType();
                product.Append(newEvent);
            }            
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
