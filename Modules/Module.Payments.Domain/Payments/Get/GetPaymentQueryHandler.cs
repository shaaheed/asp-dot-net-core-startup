using Core.Infrastructure.Queries;
using Module.Payments.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

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

        public async Task<PaymentDetailsDto> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var payment = _unitOfWork.GetRepository<Payment>()
                .AsQueryable()
                .Select(x => new PaymentDetailsDto
                {
                    Id = x.Id
                })
                .FirstOrDefault(x => x.Id == request.Id);
            return await Task.FromResult(payment);
        }
    }
}
