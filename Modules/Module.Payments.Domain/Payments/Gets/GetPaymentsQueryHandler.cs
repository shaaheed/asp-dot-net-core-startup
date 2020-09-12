using Core.Infrastructure.Queries;
using Module.Payments.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Payments.Domain
{
    public class GetPaymentsQueryHandler : IQueryHandler<GetPaymentsQuery, IEnumerable<PaymentDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetPaymentsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PaymentDto>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
        {
            var products = _unitOfWork.GetRepository<Payment>()
                .AsQueryable()
                .Select(x => new PaymentDto
                {
                    Id = x.Id
                })
                .ToList();
            return await Task.FromResult(products);
        }
    }
}
