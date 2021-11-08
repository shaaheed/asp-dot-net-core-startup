using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Module.Sales.Domain
{
    public class DeleteInvoiceCommandHandler : ICommandHandler<DeleteInvoiceCommand, Guid>
    {
        private readonly IDocumentService _documentService;

        public DeleteInvoiceCommandHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Guid> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            await _documentService.DeleteDocument<Invoice>(request.Id, LineTransactionType.Sale, cancellationToken);
            return request.Id;
        }
    }
}
