using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Module.Sales.Domain.Bills
{
    public class UpdateBillCommandHandler : ICommandHandler<UpdateBillCommand, Guid?>
    {

        private readonly IDocumentService _documentService;

        public UpdateBillCommandHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Guid?> Handle(UpdateBillCommand request, CancellationToken cancellationToken)
        {
            await _documentService.UpdateDocument(request.Id, request, request.Items, LineTransactionType.Purchase, cancellationToken);
            return request.Id;
        }
    }
}
