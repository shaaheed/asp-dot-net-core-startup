namespace Module.Sales.Domain.Invoices
{
    public class InvoiceLineItemBaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long? ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }
}
