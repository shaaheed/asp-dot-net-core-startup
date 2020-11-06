namespace Module.Sales.Domain.Invoices
{
    public class CreateInvoiceLineItemDto : InvoiceLineItemBaseDto
    {
        public long? InvoiceId { get; set; }
        public decimal Price { get; set; }
    }
}
