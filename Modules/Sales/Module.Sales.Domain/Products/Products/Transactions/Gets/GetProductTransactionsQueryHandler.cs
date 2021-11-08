using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Products
{
    public class GetProductTransactionsQueryHandler : IQueryHandler<GetProductTransactionsQuery, PagedCollection<ProductTransactionListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetProductTransactionsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<ProductTransactionListItemDto>> Handle(GetProductTransactionsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(ProductTransactionListItemDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
