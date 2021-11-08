using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Module.Sales.Domain
{
    public class UpdateBillPaymentCommandHandler : ICommandHandler<UpdateBillPaymentCommand, Guid>
    {
        private readonly IDocumentService _documentService;

        public UpdateBillPaymentCommandHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public Task<Guid> Handle(UpdateBillPaymentCommand request, CancellationToken cancellationToken)
        {
            return _documentService.UpdatePayment<Bill>(request, cancellationToken);
        }
    }
}
