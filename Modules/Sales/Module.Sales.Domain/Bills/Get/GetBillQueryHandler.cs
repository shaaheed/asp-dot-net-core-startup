using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class GetBillQueryHandler : IQueryHandler<GetBillQuery, BillDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetBillQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<BillDto> Handle(GetBillQuery request, CancellationToken cancellationToken)
        {
            var invoicePaymentAmount = _unitOfWork.GetRepository<BillPayment>()
                .Where(x => x.BillId == request.Id)
                .Select(x => x.Payment.Amount)
                .Sum();
            return _unitOfWork.GetAsync(x => x.Id == request.Id, BillDto.Selector(invoicePaymentAmount), cancellationToken);
        }
    }
}
