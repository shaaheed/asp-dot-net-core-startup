using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Invoices
{
    public class GetInvoiceQuery : IQuery<InvoiceDto>
    {
        public Guid Id { get; set; }
    }
}
