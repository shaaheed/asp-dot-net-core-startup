using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Module.Sales.Domain
{
    public class CreateBillCommandHandler : ICommandHandler<CreateBillCommand, Guid?>
    {

        private readonly IDocumentService _documentService;

        public CreateBillCommandHandler(
            IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Guid?> Handle(CreateBillCommand request, CancellationToken cancellationToken)
        {
            var newBill = request.Map();
            await _documentService.AddDocument(newBill, request.Items, LineTransactionType.Purchase, cancellationToken);
            return newBill.Id;
        }
    }
}
