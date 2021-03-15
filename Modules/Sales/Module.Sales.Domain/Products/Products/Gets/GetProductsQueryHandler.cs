using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Products
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, PagedCollection<ProductListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetProductsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<ProductListItemDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(ProductListItemDto.Selector(), request.PagingOptions, request.SearchOptions, cancellationToken);
        }
    }
}
