using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class DeleteInvoicePaymentCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
    }
}
