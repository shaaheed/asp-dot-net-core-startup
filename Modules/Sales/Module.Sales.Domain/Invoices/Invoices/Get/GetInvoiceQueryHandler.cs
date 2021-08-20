using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class GetInvoiceQueryHandler : IQueryHandler<GetInvoiceQuery, InvoiceDto>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;

        public GetInvoiceQueryHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
        }

        public Task<InvoiceDto> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var paymentAmount = _invoiceService.GetInvoicePaymentsAmount(request.Id);
            return _unitOfWork.GetAsync(x => x.Id == request.Id, InvoiceDto.Selector(paymentAmount), cancellationToken);
        }
    }
}
