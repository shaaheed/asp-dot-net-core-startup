using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class PrintInvoiceQuery : IQuery<string>
    {
        public Guid Id { get; set; }
    }
}
