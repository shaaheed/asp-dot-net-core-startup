using Module.Sales.Entities;
using Msi.Service;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public interface IInvoiceService : ITransientService
    {
        decimal GetInvoicePaymentsAmount(Guid invoiceId);

        void Calculate(Invoice invoice);

        void AddPayment(Guid invoiceId);

        void AddPayment(Invoice invoice);

        string GetNextInvoiceNumber();

        Task<int> CreateOrUpdateInvoiceLineItem(InvoiceLineItemRequestDto request, Guid invoiceId, Guid? lineItemId, CancellationToken cancellationToken = default);
    }
}
