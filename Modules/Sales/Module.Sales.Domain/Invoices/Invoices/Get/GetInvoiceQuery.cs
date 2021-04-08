using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class GetInvoiceQuery : IQuery<InvoiceDto>
    {
        public Guid Id { get; set; }
    }
}
