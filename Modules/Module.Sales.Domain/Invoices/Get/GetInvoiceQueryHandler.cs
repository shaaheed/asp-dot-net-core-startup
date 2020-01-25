using Core.Infrastructure.Queries;
using Module.Sales.Domain.Customers;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.Invoices
{
    public class GetInvoiceQueryHandler : IQueryHandler<GetInvoiceQuery, InvoiceDetailsDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetInvoiceQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<InvoiceDetailsDto> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var product = _unitOfWork.GetRepository<Invoice>()
                .AsQueryable()
                .Select(x => new InvoiceDetailsDto
                {
                    Id = x.Id,
                    Status = x.Status.ToString(),
                    Customer = x.Customer != null ? new CustomerDto
                    {
                        Id = (long)x.CustomerId,
                        Name = x.Customer.FirstName,
                        Contact = x.Customer.Contact,
                        Email = x.Customer.Email,
                        Mobile = x.Customer.Mobile
                    } : null,
                    AmountDue = x.AmountDue,
                    Total = x.GrandTotal,
                    Items = x.InvoiceLineItems.Select(i => new InvoiceLineItemDto
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
                    PaymentDueDate = x.PaymentDueDate,
                    IssueDate = x.IssueDate
                })
                .FirstOrDefault(x => x.Id == request.Id);
            return product;
        }
    }
}
