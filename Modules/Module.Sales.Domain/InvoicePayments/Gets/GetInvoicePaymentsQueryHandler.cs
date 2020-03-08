using Core.Infrastructure.Queries;
using Module.Sales.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.InvoicePayments
{
    public class GetInvoicePaymentsQueryHandler : IQueryHandler<GetInvoicePaymentsQuery, IEnumerable<InvoicePaymentDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetInvoicePaymentsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<InvoicePaymentDto>> Handle(GetInvoicePaymentsQuery request, CancellationToken cancellationToken)
        {
            var results = _unitOfWork.GetRepository<InvoicePayment>()
                .AsQueryable()
                .Select(x => new InvoicePaymentDto
                {
                    Id = x.Id,
                    Amount = x.Payment.Amount,
                    InvoiceId = x.InvoiceId,
                    Memo = x.Payment.Memo,
                    PaymentDate = x.Payment.PaymentDate,
                    PaymentMethod = new Core.Domain.IdNameDto<long>
                    {
                        Id = x.PaymentId,
                        Name = x.Payment.PaymentMethod.Name
                    }
                })
                .ToList();
            return await Task.FromResult(results);
        }
    }
}
