using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class UpdateInvoicePaymentCommandHandler : ICommandHandler<UpdateInvoicePaymentCommand, Guid>
    {

        private readonly IDocumentService _documentService;

        public UpdateInvoicePaymentCommandHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public Task<Guid> Handle(UpdateInvoicePaymentCommand request, CancellationToken cancellationToken)
        {
            return _documentService.UpdatePayment<Invoice>(request, cancellationToken);
        }
    }
}
