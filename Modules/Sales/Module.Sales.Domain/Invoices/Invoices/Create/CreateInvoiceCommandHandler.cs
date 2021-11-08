using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Module.Sales.Domain
{
    public class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand, Guid?>
    {
        private readonly IDocumentService _documentService;

        public CreateInvoiceCommandHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public Task<Guid?> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var newInvoice = request.Map();
            return _documentService.AddDocument(newInvoice, request.Items, LineTransactionType.Sale, cancellationToken);
        }
    }
}
