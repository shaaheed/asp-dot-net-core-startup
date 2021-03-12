using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Bills
{
    public class GetBillsQueryHandler : IQueryHandler<GetBillsQuery, IEnumerable<BillDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetBillsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BillDto>> Handle(GetBillsQuery request, CancellationToken cancellationToken)
        {
            var results = _unitOfWork.GetRepository<Bill>()
                .AsQueryable()
                .Select(x => new BillDto
                {
                    Id = x.Id,
                    //Vendor = x.VendorId != null ? new IdNameDto<Guid>
                    //{
                    //    Id = (Guid)x.VendorId,
                    //    Name = x.Vendor.FirstName
                    //} : null,
                    AmountDue = x.AmountDue,
                    Total = x.GrandTotal,
                    IssueDate = x.IssueDate,
                    Status = x.Status.ToString()
                })
                .ToList();
            return await Task.FromResult(results);
        }
    }
}
