namespace Module.Sales.Domain.Invoices
{
    public class UpdateInvoiceLineItemDto : InvoiceLineItemBaseDto
    {
        public long? Id { get; set; }
        public long? InvoiceId { get; set; }
    }
}
