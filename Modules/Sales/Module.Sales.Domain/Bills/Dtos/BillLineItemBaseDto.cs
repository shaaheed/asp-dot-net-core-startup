using System;

namespace Module.Sales.Domain.Bills
{
    public class BillLineItemBaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public float Quantity { get; set; }
        public string Note { get; set; }
    }
}
