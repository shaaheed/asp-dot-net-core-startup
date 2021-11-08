using Module.Sales.Entities;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain
{
    public class LineItemRequestDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        public Guid? ProductId { get; set; }
        public LineType LineType { get; set; } = LineType.Transaction;

        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public float Quantity { get; set; }

        public Guid? UnitId { get; set; }
        public List<Guid> Taxes { get; set; }

        public virtual LineItem Map(LineItem entity = null)
        {
            entity = entity ?? new LineItem();
            entity.Name = Name;
            entity.Description = Description;
            entity.ProductId = ProductId;
            entity.Quantity = Quantity;
            entity.Subtotal = (decimal)Quantity * UnitPrice;
            entity.Total = Subtotal + TotalTaxAmount;
            entity.UnitPrice = UnitPrice;
            entity.UnitId = UnitId;
            entity.Note = Note;
            entity.LineType = LineType;
            return entity;
        }
    }
}
