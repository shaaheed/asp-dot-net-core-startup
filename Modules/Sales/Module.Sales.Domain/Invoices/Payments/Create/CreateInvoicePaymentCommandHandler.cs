using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Sales.Entities;
using System;

namespace Module.Sales.Domain
{
    public class CreateInvoicePaymentCommandHandler : ICommandHandler<CreateInvoicePaymentCommand, Guid>
    {

        private readonly IDocumentService _documentService;

        public CreateInvoicePaymentCommandHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public Task<Guid> Handle(CreateInvoicePaymentCommand request, CancellationToken cancellationToken)
        {
            return _documentService.AddPayment<Invoice>(request, cancellationToken);
        }
    }
}
