using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public class DeleteInvoicePaymentCommandHandler : ICommandHandler<DeleteInvoicePaymentCommand, bool>
    {

        private readonly IDocumentService _documentService;

        public DeleteInvoicePaymentCommandHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public Task<bool> Handle(DeleteInvoicePaymentCommand request, CancellationToken cancellationToken)
        {
            return _documentService.DeletePayment<Invoice>(request, cancellationToken);
        }
    }
}
