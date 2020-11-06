using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class DeleteInvoicePaymentCommand : ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
