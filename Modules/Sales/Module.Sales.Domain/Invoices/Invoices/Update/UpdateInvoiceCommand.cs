using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class UpdateInvoiceCommand : CreateInvoiceCommand, ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
