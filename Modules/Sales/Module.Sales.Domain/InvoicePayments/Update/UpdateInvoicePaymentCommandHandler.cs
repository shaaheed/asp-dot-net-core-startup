using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain.InvoicePayments
{
    public class UpdateInvoicePaymentCommandHandler : ICommandHandler<UpdateInvoicePaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateInvoicePaymentCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateInvoicePaymentCommand request, CancellationToken cancellationToken)
        {

            var invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            var invoice = await invoiceRepo.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (invoice == null)
                throw new NotFoundException("Invoice payment not found");

            invoice.CustomerId = request.CustomerId;

            var invoiceLineItemsRepo = _unitOfWork.GetRepository<InvoiceLineItem>();
            var invoiceLineItemsToBeRemoved = invoiceLineItemsRepo.Where(x => x.InvoiceId == request.Id);
            var lineItemsToBeRemoved = invoiceLineItemsToBeRemoved.Select(x => x.LineItem);

            invoiceLineItemsRepo.RemoveRange(invoiceLineItemsToBeRemoved);
            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            lineItemRepo.RemoveRange(lineItemsToBeRemoved);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            //var newLineItems = request.Items.Select(x => new LineItem
            //{
            //    Name = x.Name,
            //    Description = x.Description,
            //    ProductId = x.ProductId,
            //    Quantity = x.Quantity,
            //    Subtotal = x.Subtotal,
            //    Total = x.Quantity * x.UnitPrice,
            //    UnitPrice = x.UnitPrice
            //});

            //var newInvoiceLineItems = newLineItems.Select(x => new InvoiceLineItem
            //{
            //    Invoice = invoice,
            //    LineItem = x
            //});

            //invoice.InvoiceLineItems = newInvoiceLineItems.ToList();
            //invoice.Calculate();

            //await invoiceRepo.AddAsync(newInvoice, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
