using System;

namespace Module.Sales.Domain
{
    public class UpdateInvoiceCommand : CreateInvoiceCommand
    {
        public Guid Id { get; set; }
    }
}
