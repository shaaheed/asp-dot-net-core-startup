using Core.Infrastructure.Queries;
using Module.Sales.Domain.Customers;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Bills
{
    public class GetBillQueryHandler : IQueryHandler<GetBillQuery, BillDetailsDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetBillQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BillDetailsDto> Handle(GetBillQuery request, CancellationToken cancellationToken)
        {
            var billPaymentAmount = _unitOfWork.GetRepository<BillPayment>()
                .Where(x => x.BillId == request.Id)
                .Select(x => x.Payment.Amount)
                .Sum();

            var result = _unitOfWork.GetRepository<Bill>()
                .AsQueryable()
                .Select(x => new BillDetailsDto
                {
                    Id = x.Id,
                    Status = x.Status.ToString(),
                    Vendor = x.Vendor != null ? new CustomerDto
                    {
                        Id = (long)x.VendorId,
                        Name = x.Vendor.FirstName,
                        Contact = x.Vendor.Contact,
                        Email = x.Vendor.Email,
                        Mobile = x.Vendor.Mobile
                    } : null,
                    AmountDue = x.AmountDue,
                    Total = x.GrandTotal,
                    Items = x.BillLineItems.Select(i => new BillLineItemDto
                    {
                        Id = i.Id,
                        Name = i.LineItem.Name,
                        Description = i.LineItem.Description,
                        ProductId = i.LineItem.ProductId,
                        Quantity = i.LineItem.Quantity,
                        Subtotal = i.LineItem.Subtotal,
                        Total = i.LineItem.Total,
                        UnitPrice = i.LineItem.UnitPrice
                    }),
                    IssueDate = x.IssueDate,
                    PaymentAmount = billPaymentAmount
                })
                .FirstOrDefault(x => x.Id == request.Id);
            return await Task.FromResult(result);
        }
    }
}
