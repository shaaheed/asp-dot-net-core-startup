using Module.Sales.Entities;
using Msi.Service;
using System;

namespace Module.Sales.Domain
{
    public interface IInvoiceService : ITransientService
    {
        decimal GetInvoicePaymentsAmount(Guid invoiceId);

        void AddPayment(Guid invoiceId);

        void AddPayment(Invoice invoice);

        string GetNextInvoiceNumber();
    }
}
