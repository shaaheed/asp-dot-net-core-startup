using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Utilities.Filter;
using Module.Payments.Domain;

namespace Module.Sales.Domain
{
    public class GetInvoicePaymentsQueryHandler : IQueryHandler<GetInvoicePaymentsQuery, PagedCollection<PaymentDetailsDto>>
    {

        private readonly IDocumentService _documentService;

        public GetInvoicePaymentsQueryHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public Task<PagedCollection<PaymentDetailsDto>> Handle(GetInvoicePaymentsQuery request, CancellationToken cancellationToken)
        {
            return _documentService.GetPayments(request, cancellationToken);
        }
    }
}
