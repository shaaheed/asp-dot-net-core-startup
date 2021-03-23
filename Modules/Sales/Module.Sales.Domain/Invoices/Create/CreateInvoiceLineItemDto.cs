using System;

namespace Module.Sales.Domain.Invoices
{
    public class CreateInvoiceLineItemDto : InvoiceLineItemBaseDto
    {
        public Guid? InvoiceId { get; set; }
    }
}
