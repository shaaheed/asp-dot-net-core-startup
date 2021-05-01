using Msi.Mediator.Abstractions;
using System.Threading;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public class GetBillsQueryHandler : IQueryHandler<GetBillsQuery, PagedCollection<BillListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetBillsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<BillListItemDto>> Handle(GetBillsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(BillListItemDto.Selector(), request.PagingOptions, request.SearchOptions, cancellationToken);
        }
    }
}
