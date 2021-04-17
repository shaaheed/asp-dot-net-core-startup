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

        void AddPayment(Guid invoiceId);

        void AddPayment(Invoice invoice);

        string GetNextInvoiceNumber();

        Task<int> CreateOrUpdateInvoiceLineItem(
            InvoiceLineItemRequestDto request,
            Guid? lineItemId,
            CancellationToken cancellationToken = default);

        Task<int> CreateOrUpdateInventoryAdjustment(
            string invoiceNumber,
            Guid productId,
            float productQuantity,
            bool increase,
            bool decrease,
            CancellationToken cancellationToken = default);
    }
}
