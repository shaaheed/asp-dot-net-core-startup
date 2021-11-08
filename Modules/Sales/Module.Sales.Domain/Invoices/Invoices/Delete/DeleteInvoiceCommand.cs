using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class DeleteInvoiceCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }
    }
}
