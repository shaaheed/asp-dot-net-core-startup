using Module.Sales.Entities;
using Msi.Service;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public interface IBillService : ITransientService
    {
        decimal GetBillPaymentsAmount(Guid invoiceId);

        void Calculate(Bill invoice);

        void AddPayment(Guid invoiceId);

        void AddPayment(Bill invoice);

        string GetNextBillNumber();

        Task<int> CreateOrUpdateBillLineItem(BillLineItemRequestDto request, Guid billId, Guid? lineItemId, CancellationToken cancellationToken = default);
    }
}
