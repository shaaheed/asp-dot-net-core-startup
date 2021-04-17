using Module.Sales.Entities;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain
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

        public virtual LineItem Map(LineItem entity = null)
        {
            entity = entity ?? new LineItem();
            entity.Name = Name;
            entity.Description = Description;
            entity.ProductId = ProductId;
            entity.Quantity = Quantity;
            entity.Subtotal = Subtotal;
            entity.Total = (decimal)Quantity * UnitPrice;
            entity.UnitPrice = UnitPrice;
            entity.UnitId = UnitId;
            entity.Note = Note;
            return entity;
        }
    }
}
