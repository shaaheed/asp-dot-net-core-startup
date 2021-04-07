using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Payments.Entities;
using System.Linq;

namespace Module.Payments.Domain
{
    public class GetPaymentCreateInfoQueryHandler : IQueryHandler<GetPaymentCreateInfoQuery, PaymentCreateInfoDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetPaymentCreateInfoQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PaymentCreateInfoDto> Handle(GetPaymentCreateInfoQuery request, CancellationToken cancellationToken)
        {
            var count = _unitOfWork.GetRepository<Payment>()
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => x.Id)
                .LongCount();
            var nextPaymentNumber = $"PAY-{count + 1}";
            var info = new PaymentCreateInfoDto
            {
                NextPaymentNumber = nextPaymentNumber
            };
            return Task.FromResult(info);
        }
    }
}
