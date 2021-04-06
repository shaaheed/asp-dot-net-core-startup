using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Sales.Domain.Services;

namespace Module.Sales.Domain.Invoices
{
    public class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;

        public CreateInvoiceCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
        }

        public async Task<long> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {

            var invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            var newInvoice = request.Map();

            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            var newLineItems = request.Items.Select(x => new LineItem
            {
                Name = x.Name,
                Description = x.Description,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Subtotal = x.Subtotal,
                Total = (decimal)x.Quantity * x.UnitPrice,
                UnitPrice = x.UnitPrice,
                UnitId = x.UnitId,
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
            _invoiceService.AddPayment(newInvoice);

            await invoiceRepo.AddAsync(newInvoice, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
