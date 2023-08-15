using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Items
{
    public class GetProductTransactionsQueryHandler : IQueryHandler<GetProductTransactionsQuery, PagedCollection<ItemTransactionListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetProductTransactionsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<ItemTransactionListItemDto>> Handle(GetProductTransactionsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(ItemTransactionListItemDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
