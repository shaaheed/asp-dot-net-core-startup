using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Payments.Domain;

namespace Module.Sales.Domain.InvoicePayments
{
    public class GetBillPaymentQueryHandler : IQueryHandler<GetBillPaymentQuery, PaymentDetailsDto>
    {

        private readonly IDocumentService _documentService;

        public GetBillPaymentQueryHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public Task<PaymentDetailsDto> Handle(GetBillPaymentQuery request, CancellationToken cancellationToken)
        {
            return _documentService.GetPayment(request, cancellationToken);
        }
    }
}
