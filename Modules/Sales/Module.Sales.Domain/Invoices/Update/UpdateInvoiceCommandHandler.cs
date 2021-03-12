using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain.Invoices
{
    public class UpdateInvoiceCommandHandler : ICommandHandler<UpdateInvoiceCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateInvoiceCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {

            var invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            var invoice = await invoiceRepo.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (invoice == null)
                throw new NotFoundException("Invoice not found");

            invoice.CustomerId = request.CustomerId;
            invoice.Note = request.Note;
            invoice.Memo = request.Memo;

            var invoiceLineItemsRepo = _unitOfWork.GetRepository<InvoiceLineItem>();
            var invoiceLineItemsToBeRemoved = invoiceLineItemsRepo.Where(x => x.InvoiceId == request.Id);
            var lineItemsToBeRemoved = invoiceLineItemsToBeRemoved.Select(x => x.LineItem);

            invoiceLineItemsRepo.RemoveRange(invoiceLineItemsToBeRemoved);
            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            lineItemRepo.RemoveRange(lineItemsToBeRemoved);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var newLineItems = request.Items.Select(x => new LineItem
            {
                Name = x.Name,
                Description = x.Description,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Subtotal = x.Subtotal,
                Total = x.Quantity * x.UnitPrice,
                UnitPrice = x.UnitPrice
            });

            var newInvoiceLineItems = newLineItems.Select(x => new InvoiceLineItem
            {
                Invoice = invoice,
                LineItem = x
            });

            invoice.InvoiceLineItems = newInvoiceLineItems.ToList();
            invoice.Calculate();

            invoice.AmountDue = 0;
            //var invoicePaymentAmount = _unitOfWork.GetRepository<InvoicePayment>()
            //    .Where(x => x.InvoiceId == invoice.Id)
            //    .Select(x => x.Payment.Amount)
            //    .Sum();

            //invoice.AddPayment(invoicePaymentAmount);
            
            //if (invoicePaymentAmount > invoice.GrandTotal)
            //{
                // Over paid.
                // TODO: Create credit note
            //}

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
