using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class DeleteInvoiceCommand : ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
