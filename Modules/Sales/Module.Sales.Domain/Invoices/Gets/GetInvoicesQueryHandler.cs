using Msi.Mediator.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Invoices
{
    public class GetInvoicesQueryHandler : IQueryHandler<GetInvoicesQuery, IEnumerable<InvoiceDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetInvoicesQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<InvoiceDto>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            //var results = _unitOfWork.GetRepository<Invoice>()
            //    .AsQueryable()
            //    .Select(x => new InvoiceDto
            //    {
            //        Id = x.Id,
            //        Customer = x.CustomerId != null ? new IdNameDto<Guid>
            //        {
            //            Id = (Guid)x.CustomerId,
            //            Name = x.Customer.FirstName
            //        } : null,
            //        AmountDue = x.AmountDue,
            //        Total = x.GrandTotal,
            //        IssueDate = x.IssueDate,
            //        Status = x.Status.ToString()
            //    })
            //    .ToList();
            //return await Task.FromResult(results);
            return null;
        }
    }
}
