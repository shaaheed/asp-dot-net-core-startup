using Core.Infrastructure.Commands;
using Module.Sales.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.Invoices
{
    public class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateInvoiceCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {

            var invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            var newInvoice = new Invoice
            {
                Status = InvoiceStatus.Unpaid,
                IssueDate = DateTimeOffset.UtcNow,
                PaymentDueDate = DateTimeOffset.UtcNow,
                CustomerId = request.CustomerId,
                Note = request.Note,
                Memo = request.Memo
            };

            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            var newLineItems = request.Items.Select(x => new LineItem
            {
                Name = x.Name,
                Description = x.Description,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Subtotal = x.Subtotal,
                Total = x.Quantity * x.UnitPrice,
                UnitPrice = x.UnitPrice,
                Note = x.Note
            });

            var invoiceLineItemsRepo = _unitOfWork.GetRepository<InvoiceLineItem>();
            var newInvoiceLineItems = newLineItems.Select(x => new InvoiceLineItem
            {
                Invoice = newInvoice,
                LineItem = x
            });

            newInvoice.InvoiceLineItems = newInvoiceLineItems.ToList();
            newInvoice.Calculate();

            await invoiceRepo.AddAsync(newInvoice, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
