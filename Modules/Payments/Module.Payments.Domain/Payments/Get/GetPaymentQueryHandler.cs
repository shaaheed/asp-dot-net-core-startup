using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Payments.Domain
{
    public class GetPaymentQueryHandler : IQueryHandler<GetPaymentQuery, PaymentDetailsDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPaymentQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PaymentDetailsDto> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id && x.DocumentId == request.DocumentId, PaymentDetailsDto.Selector(), cancellationToken);
        }
    }
}
