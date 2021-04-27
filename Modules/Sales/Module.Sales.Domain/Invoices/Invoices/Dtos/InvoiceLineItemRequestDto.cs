using System;

namespace Module.Sales.Domain
{
    public class InvoiceLineItemRequestDto : BaseInvoiceLineItemRequestDto
    {
        public Guid? InvoiceId { get; set; }
    }
}
