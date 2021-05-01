using Module.Sales.Entities;
using Msi.Core;
using Msi.Data.Abstractions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Invoice> _invoiceRepo;
        private readonly IRepository<InvoiceLineItem> _invoiceLineItemRepo;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            _invoiceLineItemRepo = _unitOfWork.GetRepository<InvoiceLineItem>();
        }

        public void AddPayment(Guid invoiceId)
        {
            var invoice = _invoiceRepo
                .Where(x => x.Id == invoiceId && !x.IsDeleted)
                .FirstOrDefault();
            AddPayment(invoice);
        }

        public void Calculate(Invoice invoice)
        {
            if (invoice != null)
            {
                decimal grandTotal = 0;
                decimal subtotal = 0;
                var lineItems = _invoiceLineItemRepo
                    .WhereAsReadOnly(x => x.InvoiceId == invoice.Id)
                    .Select(x => new
                    {
                        Total = x.LineItem.Total,
                        Subtotal = x.LineItem.Subtotal
                    });
                foreach (var item in lineItems)
                {
                    grandTotal += item.Total;
                    subtotal += item.Subtotal;
                }
                invoice.GrandTotal = grandTotal;
                invoice.Subtotal = subtotal;
            }
        }

        public void AddPayment(Invoice invoice)
        {
            if (invoice != null)
            {
                var paymentsAmount = GetInvoicePaymentsAmount(invoice.Id);
                if (invoice.GrandTotal == paymentsAmount)
                {
                    // Full payment
                    invoice.Status = Status.Paid;
                    invoice.AmountDue = 0;
                }
                else if (invoice.GrandTotal > paymentsAmount)
                {
                    invoice.Status = Status.Due;
                }

                if (paymentsAmount <= invoice.GrandTotal)
                {
                    invoice.AmountDue = invoice.GrandTotal - paymentsAmount;
                }
            }
        }

        public decimal GetInvoicePaymentsAmount(Guid invoiceId)
        {
            var paymentAmount = _unitOfWork.GetRepository<InvoicePayment>()
                .WhereAsReadOnly(x => x.InvoiceId == invoiceId && !x.Invoice.IsDeleted)
                .Select(x => x.Payment.Amount)
                .Sum();
            return paymentAmount;
        }

        public string GetNextInvoiceNumber()
        {
            var count = _invoiceRepo
                .WhereAsReadOnly(x => !x.IsDeleted)
                .Select(x => x.Id)
                .LongCount();

            return $"INV-{count + 1}";
        }

        public async Task<int> CreateOrUpdateInvoiceLineItem(
            InvoiceLineItemRequestDto request,
            Guid invoiceId,
            Guid? lineItemId,
            CancellationToken cancellationToken = default)
        {
            var lineItem = request.Map();
            var invoiceLineItem = new InvoiceLineItem();
            if (request.Id.HasValue)
            {
                var savedInvoiceLineItem = await _invoiceLineItemRepo
                    .FirstOrDefaultAsyncAsReadOnly(x => x.Id == request.Id.Value, x => new
                    {
                        Id = x.Id,
                        LineItemId = x.LineItemId
                    });

                if (savedInvoiceLineItem == null)
                    throw new ValidationException("Line item not found");

                invoiceLineItem.Id = request.Id.Value;
                _invoiceLineItemRepo.Attach(invoiceLineItem);
                if (lineItemId.HasValue)
                {
                    var savedLineItem = await _unitOfWork.GetRepository<LineItem>()
                        .FirstOrDefaultAsyncAsReadOnly(x => x.Id == lineItemId.Value && !x.IsDeleted, x => new { Id = x.Id }, cancellationToken);
                    if (savedLineItem == null)
                        throw new ValidationException("Line item not found.");

                    lineItem.Id = lineItemId.Value;
                    invoiceLineItem.LineItemId = lineItemId.Value;
                    invoiceLineItem.LineItem = lineItem;
                }
            }
            else
            {
                invoiceLineItem.LineItem = lineItem;
                invoiceLineItem.InvoiceId = invoiceId;
                await _invoiceLineItemRepo.AddAsync(invoiceLineItem, cancellationToken);
            }
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }

    }
}
