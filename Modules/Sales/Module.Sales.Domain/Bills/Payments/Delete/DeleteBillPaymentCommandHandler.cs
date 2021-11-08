using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public class DeleteBillPaymentCommandHandler : ICommandHandler<DeleteBillPaymentCommand, bool>
    {

        private readonly IDocumentService _documentService;

        public DeleteBillPaymentCommandHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public Task<bool> Handle(DeleteBillPaymentCommand request, CancellationToken cancellationToken)
        {
            return _documentService.DeletePayment<Bill>(request, cancellationToken);
        }
    }
}
