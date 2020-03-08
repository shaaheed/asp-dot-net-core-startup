using Core.Infrastructure.Queries;
using Module.Payments.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Payments.Domain
{
    public class GetPaymentMethodsQueryHandler : IQueryHandler<GetPaymentMethodsQuery, IEnumerable<PaymentMethodDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetPaymentMethodsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PaymentMethodDto>> Handle(GetPaymentMethodsQuery request, CancellationToken cancellationToken)
        {
            var results = _unitOfWork.GetRepository<PaymentMethod>()
                .AsQueryable()
                .Select(x => new PaymentMethodDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name
                })
                .ToList();
            return await Task.FromResult(results);
        }
    }
}
