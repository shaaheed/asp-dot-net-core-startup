using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Invoices
{
    public class DeleteInvoiceCommand : ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
