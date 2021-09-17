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

        public async Task<InvoiceDto> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var paymentAmount = _invoiceService.GetInvoicePaymentsAmount(request.Id);
            var invoice = await _unitOfWork.GetAsync(x => x.Id == request.Id, InvoiceDto.Selector(paymentAmount), cancellationToken);
            if (invoice != null)
            {
                var collection = await _unitOfWork.ListAsync(x => x.ReferenceId == invoice.Id && x.Type == Entities.ItemTransactionType.Sale && !x.IsDeleted, LineItemDto.Selector(), null, cancellationToken);
                invoice.Items = collection.Items;
            }
            return invoice;
        }
    }
}
