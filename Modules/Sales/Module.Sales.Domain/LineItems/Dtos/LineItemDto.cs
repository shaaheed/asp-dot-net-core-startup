using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class LineItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? ContactId { get; set; }
        public LineType LineType { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public float Quantity { get; set; }
        public string Note { get; set; }
        public GuidCodeNameDto Unit { get; set; }

        public static Expression<Func<LineItem, LineItemDto>> Selector()
        {
            return x => new LineItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                Subtotal = x.Subtotal,
                Total = x.Total,
                TotalTaxAmount = x.TotalTaxAmount,
                Quantity = x.Quantity,
                Note = x.Note,
                Unit = x.UnitId != null ? new GuidCodeNameDto
                {
                    Id = x.UnitId.Value,
                    Code = x.Unit.Name,
                    Name = x.Unit.Name
                } : null,
                AccountId = x.AccountId,
                ContactId = x.ContactId,
                LineType = x.LineType
            };
        }
    }
}
