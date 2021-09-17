using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class GetBillQueryHandler : IQueryHandler<GetBillQuery, BillDto>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillService _billService;

        public GetBillQueryHandler(
            IUnitOfWork unitOfWork,
            IBillService billService)
        {
            _unitOfWork = unitOfWork;
            _billService = billService;
        }

        public async Task<BillDto> Handle(GetBillQuery request, CancellationToken cancellationToken)
        {
            var paymentAmount = _billService.GetBillPaymentsAmount(request.Id);
            var bill = await _unitOfWork.GetAsync(x => x.Id == request.Id, BillDto.Selector(paymentAmount), cancellationToken);
            if (bill != null)
            {
                var collection = await _unitOfWork.ListAsync(x => x.ReferenceId == bill.Id && x.Type == Entities.ItemTransactionType.Purchase && !x.IsDeleted, LineItemDto.Selector(), null, cancellationToken);
                bill.Items = collection.Items;
            }
            return bill;
        }
    }
}
