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
        private readonly IDocumentService _documentService;

        public GetInvoiceQueryHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService,
            IDocumentService documentService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
            _documentService = documentService;
        }

        public async Task<InvoiceDto> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var paymentAmount = _documentService.GetPaymentsAmount(request.Id);
            var invoice = await _unitOfWork.GetAsync(x => x.Id == request.Id, InvoiceDto.Selector(paymentAmount), cancellationToken);
            if (invoice != null)
            {
                var collection = await _unitOfWork.ListAsync(x => x.DocumentId == invoice.Id && x.TransactionType == Entities.LineTransactionType.Sale && !x.IsDeleted, LineItemDto.Selector(), null, cancellationToken);
                invoice.Items = collection.Items;
            }
            return invoice;
        }
    }
}
