using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Payments.Domain;

namespace Module.Sales.Domain
{
    public class GetInvoicePaymentQueryHandler : IQueryHandler<GetInvoicePaymentQuery, PaymentDetailsDto>
    {

        private readonly IDocumentService _documentService;

        public GetInvoicePaymentQueryHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public Task<PaymentDetailsDto> Handle(GetInvoicePaymentQuery request, CancellationToken cancellationToken)
        {
            return _documentService.GetPayment(request, cancellationToken);
        }
    }
}
