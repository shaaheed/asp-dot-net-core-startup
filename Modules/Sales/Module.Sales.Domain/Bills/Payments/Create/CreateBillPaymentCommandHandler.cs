using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Sales.Entities;
using System;

namespace Module.Sales.Domain
{
    public class CreateBillPaymentCommandHandler : ICommandHandler<CreateBillPaymentCommand, Guid>
    {
        private readonly IDocumentService _documentService;

        public CreateBillPaymentCommandHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public Task<Guid> Handle(CreateBillPaymentCommand request, CancellationToken cancellationToken)
        {
            return _documentService.AddPayment<Bill>(request, cancellationToken);
        }
    }
}
