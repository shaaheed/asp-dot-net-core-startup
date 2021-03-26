using Module.Systems.Domain;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Invoices
{
    public class InvoiceLineItemRequestDto
    {
        public Guid? Id { get; set; }
        public Guid? InvoiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public float Quantity { get; set; }
        public string Note { get; set; }
        public Guid? UnitId { get; set; }
        public List<Guid> Taxes { get; set; }
    }
}
