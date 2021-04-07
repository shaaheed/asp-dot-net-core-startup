using Module.Sales.Entities;
using Msi.Data.Abstractions;
using System;
using System.Linq;

namespace Module.Sales.Domain.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddPayment(Guid invoiceId)
        {
            var invoice = _unitOfWork.GetRepository<Invoice>()
                .Where(x => x.Id == invoiceId && !x.IsDeleted)
                .FirstOrDefault();
            AddPayment(invoice);
        }

        public void AddPayment(Invoice invoice)
        {
            if (invoice != null)
            {
                var paymentsAmount = GetInvoicePaymentsAmount(invoice.Id);
                invoice.AddPayment(paymentsAmount);
            }
        }

        public decimal GetInvoicePaymentsAmount(Guid invoiceId)
        {
            var paymentAmount = _unitOfWork.GetRepository<InvoicePayment>()
                .AsReadOnly()
                .Where(x => x.InvoiceId == invoiceId && !x.IsDeleted)
                .Select(x => x.Payment.Amount)
                .Sum();
            return paymentAmount;
        }

        public string GetNextInvoiceNumber()
        {
            var count = _unitOfWork.GetRepository<Invoice>()
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => x.Id)
                .LongCount();

            return $"INV-{count + 1}";
        }

    }
}
