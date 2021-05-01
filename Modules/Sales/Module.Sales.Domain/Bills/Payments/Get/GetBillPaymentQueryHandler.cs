using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.InvoicePayments
{
    public class GetBillPaymentQueryHandler : IQueryHandler<GetBillPaymentQuery, BillPaymentDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetBillPaymentQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<BillPaymentDto> Handle(GetBillPaymentQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, BillPaymentDto.Selector(), cancellationToken);
        }
    }
}
