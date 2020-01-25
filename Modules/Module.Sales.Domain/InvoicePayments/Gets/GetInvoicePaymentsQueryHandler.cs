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
            var products = _unitOfWork.GetRepository<Invoice>()
                .AsQueryable()
                .Select(x => new InvoicePaymentDto
                {
                    Id = x.Id,
                    AmountDue = x.AmountDue,
                    Total = x.GrandTotal,
                    IssueDate = x.IssueDate,
                    Status = x.Status.ToString()
                })
                .ToList();
            return products;
        }
    }
}
