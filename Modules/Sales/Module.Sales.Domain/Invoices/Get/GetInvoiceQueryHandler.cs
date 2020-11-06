using Msi.Mediator.Abstractions;
using Module.Sales.Domain.Customers;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using System;

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
            var invoicePaymentAmount = _unitOfWork.GetRepository<InvoicePayment>()
                .Where(x => x.InvoiceId == request.Id)
                .Select(x => x.Payment.Amount)
                .Sum();

            var result = _unitOfWork.GetRepository<Invoice>()
                .AsQueryable()
                .Select(x => new InvoiceDetailsDto
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
                    IssueDate = x.IssueDate,
                    PaymentAmount = invoicePaymentAmount,
                    Note = x.Note,
                    Memo = x.Memo
                })
                .FirstOrDefault(x => x.Id == request.Id);
            return await Task.FromResult(result);
        }
    }
}
