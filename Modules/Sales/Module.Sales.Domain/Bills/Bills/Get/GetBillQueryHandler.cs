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
        private readonly IBillService _billService;

        public GetBillQueryHandler(
            IUnitOfWork unitOfWork,
            IBillService billService)
        {
            _unitOfWork = unitOfWork;
            _billService = billService;
        }

        public Task<BillDto> Handle(GetBillQuery request, CancellationToken cancellationToken)
        {
            var paymentAmount = _billService.GetBillPaymentsAmount(request.Id);
            return _unitOfWork.GetAsync(x => x.Id == request.Id, BillDto.Selector(paymentAmount), cancellationToken);
        }
    }
}
