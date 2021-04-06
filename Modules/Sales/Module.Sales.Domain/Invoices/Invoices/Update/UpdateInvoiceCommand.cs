using Modules.Sales.Domain.Invoices;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Invoices
{
    public class UpdateInvoiceCommand : InvoiceRequestDto, ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
