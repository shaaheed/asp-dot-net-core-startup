using Module.Sales.Entities;
using Msi.Service;
using System;

namespace Module.Sales.Domain
{
    public interface IInvoiceService : ISalesService, IScopedService
    {
        decimal GetInvoicePaymentsAmount(Guid invoiceId);

        void Calculate(Invoice invoice);

        void AddPayment(Guid invoiceId);

        void AddPayment(Invoice invoice);

        string GetNextInvoiceNumber();

        decimal GetReceivablesAmount(Guid? customerId);

        Guid? GetCustomerId(Guid invoiceId);
    }
}
