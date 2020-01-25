using Core.Infrastructure.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

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
            var product = _unitOfWork.GetRepository<Entities.Product>()
                .AsQueryable()
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    Description = x.Description,
                    Price = x.Price,
                    IsBuy = x.IsBuy,
                    IsSale = x.IsSale
                })
                .FirstOrDefault(x => x.Id == request.Id);
            return product;
        }
    }
}
