using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Items
{
    public class ItemTransactionListItemDto
    {
        public Guid Id { get; set; }
        public IdNameDto<Guid?> Product { get; set; }
        public IdNameDto<Guid?> Document { get; set; }
        public IdNameDto<Guid?> Contact { get; set; }
        public GuidIdNameDto Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public float Quantity { get; set; }
        public string Type { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public static Expression<Func<LineItem, ItemTransactionListItemDto>> Selector()
        {
            return x => new ItemTransactionListItemDto
            {
                Id = x.Id,
                Product = new IdNameDto<Guid?> { Id = x.ProductId, Name = x.Name },
                Unit = x.UnitId != null ? new GuidIdNameDto { Id = x.UnitId.Value, Name = x.Unit.Name } : null,
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
                Document = new IdNameDto<Guid?> { Id = x.DocumentId, Name = x.DocumentName },
                Contact = new IdNameDto<Guid?> { Id = x.ContactId, Name = x.Contact.DisplayName },
                Type = x.TransactionType.ToString(),
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            };
        }
    }
}
