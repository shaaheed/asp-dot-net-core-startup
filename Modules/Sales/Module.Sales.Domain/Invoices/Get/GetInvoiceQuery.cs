using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Invoices
{
    public class GetInvoiceQuery : IQuery<InvoiceDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
