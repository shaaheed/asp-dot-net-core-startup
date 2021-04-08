using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain
{
    public class GetInvoicesQueryHandler : IQueryHandler<GetInvoicesQuery, PagedCollection<InvoiceListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetInvoicesQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<InvoiceListItemDto>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(InvoiceListItemDto.Selector(), request.PagingOptions, request.SearchOptions, cancellationToken);
        }
    }
}
