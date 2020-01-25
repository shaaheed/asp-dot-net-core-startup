using Core.Infrastructure.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.Products
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetProductsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _unitOfWork.GetRepository<Entities.Product>()
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
                .ToList();
            return await Task.FromResult(products);
        }
    }
}
