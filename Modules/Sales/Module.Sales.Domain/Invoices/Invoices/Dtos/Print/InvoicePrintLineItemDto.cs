namespace Module.Sales.Domain
{
    public class InvoicePrintLineItemDto
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
    }
}
