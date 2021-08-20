using Module.Sales.Entities;
using Msi.Service;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public interface IBillService : IScopedService
    {
        decimal GetBillPaymentsAmount(Guid billId);

        void Calculate(Bill invoice);

        void AddPayment(Guid invoiceId);

        void AddPayment(Bill invoice);

        string GetNextBillNumber();

        Task<int> CreateOrUpdateBillLineItem(BillLineItemRequestDto request, Guid billId, Guid? lineItemId, CancellationToken cancellationToken = default);

        decimal GetPayablesAmount(Guid? supplierId);

        Guid? GetSupplierId(Guid billId);
    }
}
