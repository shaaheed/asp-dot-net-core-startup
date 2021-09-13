using Module.Sales.Entities;
using Msi.Core;
using Msi.Data.Abstractions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public class InvoiceService : SalesService, IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        private readonly IRepository<Invoice> _invoiceRepo;
        private readonly IRepository<LineItem> _lineItemRepo;

        public InvoiceService(
            IUnitOfWork unitOfWork,
            IProductService productService) : base(unitOfWork, productService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
            _invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            _lineItemRepo = _unitOfWork.GetRepository<LineItem>();
        }

        public override Task<int> OnLineItemQuantityIncreased(Guid productId, float quantity, CancellationToken cancellationToken = default)
        {
            // stock will be decrease as product has gone from system
            return _productService.DecreaseStockQuantity(productId, quantity, cancellationToken);
        }

        public override Task<int> OnLineItemQuantityDecreased(Guid productId, float quantity, CancellationToken cancellationToken = default)
        {
            // stock will be increase as product has come into system
            return _productService.IncreaseStockQuantity(productId, quantity, cancellationToken);
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
                var lineItems = _lineItemRepo
                    .WhereAsReadOnly(x => x.ReferenceId == invoice.Id && !x.IsDeleted)
                    .Select(x => new
                    {
                        Total = x.Total,
                        Subtotal = x.Subtotal
                    });
                foreach (var item in lineItems)
                {
                    grandTotal += item.Total;
                    subtotal += item.Subtotal;
                }
                grandTotal += invoice.AdjustmentAmount;
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

        public decimal GetReceivablesAmount(Guid? customerId)
        {
            if (customerId == null) return 0;
            decimal amount = _invoiceRepo
                .WhereAsReadOnly(x => x.CustomerId == customerId && x.AmountDue > 0 && !x.IsDeleted)
                .Select(x => x.AmountDue)
                .Sum();
            return amount;
        }

        public Guid? GetCustomerId(Guid invoiceId)
        {
            return _invoiceRepo
                .WhereAsReadOnly(x => x.Id == invoiceId && !x.IsDeleted)
                .Select(x => x.CustomerId)
                .FirstOrDefault();
        }

    }
}
