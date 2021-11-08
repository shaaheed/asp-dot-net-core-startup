using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Module.Sales.Domain
{
    public class DeleteBillCommandHandler : ICommandHandler<DeleteBillCommand, Guid>
    {
        private readonly IDocumentService _documentService;

        public DeleteBillCommandHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Guid> Handle(DeleteBillCommand request, CancellationToken cancellationToken)
        {
            await _documentService.DeleteDocument<Bill>(request.Id, LineTransactionType.Purchase, cancellationToken);
            return request.Id;
        }
    }
}
