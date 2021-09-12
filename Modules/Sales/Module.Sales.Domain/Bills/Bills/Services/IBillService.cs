using Module.Sales.Entities;
using Msi.Service;
using System;

namespace Module.Sales.Domain
{
    public interface IBillService : IScopedService
    {
        decimal GetBillPaymentsAmount(Guid billId);

        void Calculate(Bill invoice);

        void AddPayment(Guid invoiceId);

        void AddPayment(Bill invoice);

        string GetNextBillNumber();

        decimal GetPayablesAmount(Guid? supplierId);

        Guid? GetSupplierId(Guid billId);
    }
}
