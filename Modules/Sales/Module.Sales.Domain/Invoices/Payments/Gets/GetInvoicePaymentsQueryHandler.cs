using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain
{
    public class GetInvoicePaymentsQueryHandler : IQueryHandler<GetInvoicePaymentsQuery, PagedCollection<InvoicePaymentDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetInvoicePaymentsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<InvoicePaymentDto>> Handle(GetInvoicePaymentsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(x => x.InvoiceId == request.InvoiceId, InvoicePaymentDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
