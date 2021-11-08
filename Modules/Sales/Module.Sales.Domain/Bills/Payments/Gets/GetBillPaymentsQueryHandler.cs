using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Utilities.Filter;
using Module.Payments.Domain;

namespace Module.Sales.Domain
{
    public class GetBillPaymentsQueryHandler : IQueryHandler<GetBillPaymentsQuery, PagedCollection<PaymentDetailsDto>>
    {

        private readonly IDocumentService _documentService;

        public GetBillPaymentsQueryHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public Task<PagedCollection<PaymentDetailsDto>> Handle(GetBillPaymentsQuery request, CancellationToken cancellationToken)
        {
            return _documentService.GetPayments(request, cancellationToken);
        }
    }
}
