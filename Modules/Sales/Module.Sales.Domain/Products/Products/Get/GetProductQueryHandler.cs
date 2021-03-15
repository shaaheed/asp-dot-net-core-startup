using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using Module.Core.Domain;

namespace Module.Sales.Domain.Products
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetProductQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetAsync(x => x.Id == request.Id, ProductDto.Selector(), cancellationToken);
            var categories = _unitOfWork.GetRepository<ProductCategory>()
                .Where(x => !x.IsDeleted && x.ProductId == request.Id)
                .Select(x => new GuidIdNameDto
                {
                    Id = x.CategoryId,
                    Name = x.Category.Name
                });
            product.Categories = categories;
            return product;
        }
    }
}
