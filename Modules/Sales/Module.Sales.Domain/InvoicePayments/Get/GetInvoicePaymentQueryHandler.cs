using Msi.Mediator.Abstractions;
using Module.Sales.Domain.Customers;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class GetInvoicePaymentQueryHandler : IQueryHandler<GetInvoicePaymentQuery, InvoicePaymentDetailsDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetInvoicePaymentQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<InvoicePaymentDetailsDto> Handle(GetInvoicePaymentQuery request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.GetRepository<Invoice>()
                .AsQueryable()
                .Select(x => new InvoicePaymentDetailsDto
                {
                    Id = x.Id,
                    Status = x.Status.ToString(),
                    Customer = x.Customer != null ? new CustomerDto
                    {
                        Id = (Guid)x.CustomerId,
                        Name = x.Customer.FirstName,
                        Contact = x.Customer.Contact,
                        Email = x.Customer.Email,
                        Mobile = x.Customer.Mobile
                    } : null,
                    AmountDue = x.AmountDue,
                    Total = x.GrandTotal,
                    PaymentDueDate = x.PaymentDueDate,
                    IssueDate = x.IssueDate
                })
                .FirstOrDefault(x => x.Id == request.Id);
            return await Task.FromResult(result);
        }
    }
}
