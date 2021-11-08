using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Sales.Entities;

namespace Module.Sales.Domain
{
    public class GetBillQueryHandler : IQueryHandler<GetBillQuery, BillDto>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IDocumentService _documentService;

        public GetBillQueryHandler(
            IUnitOfWork unitOfWork,
            IDocumentService documentService)
        {
            _unitOfWork = unitOfWork;
            _documentService = documentService;
        }

        public async Task<BillDto> Handle(GetBillQuery request, CancellationToken cancellationToken)
        {
            var paymentAmount = _documentService.GetPaymentsAmount(request.Id, cancellationToken);
            var bill = await _unitOfWork.GetAsync(x => x.Id == request.Id, BillDto.Selector(paymentAmount), cancellationToken);
            if (bill != null)
            {
                var collection = await _unitOfWork.ListAsync(x => x.DocumentId == bill.Id && x.TransactionType == LineTransactionType.Purchase && !x.IsDeleted, LineItemDto.Selector(), null, cancellationToken);
                bill.Items = collection.Items;
            }
            return bill;
        }
    }
}
