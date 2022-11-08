using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using System.Linq;

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
            var entity = request.Map();
            var repo = _unitOfWork.GetRepository<Item>();
            await repo.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (request.Categories?.Count > 0 && result > 0)
            {
                var categories = request.Categories.Select(x => new ItemCategory
                {
                    CategoryId = x,
                    ItemId = entity.Id
                });
                await _unitOfWork.GetRepository<ItemCategory>().AddRangeAsync(categories, cancellationToken);
                result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            return result;
        }
    }
}
