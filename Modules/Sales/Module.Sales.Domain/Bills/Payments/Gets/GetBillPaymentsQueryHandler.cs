using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain
{
    public class GetBillPaymentsQueryHandler : IQueryHandler<GetBillPaymentsQuery, PagedCollection<BillPaymentDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetBillPaymentsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<BillPaymentDto>> Handle(GetBillPaymentsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(x => x.BillId == request.BillId, BillPaymentDto.Selector(), request.PagingOptions, request.SearchOptions, cancellationToken);
        }
    }
}
