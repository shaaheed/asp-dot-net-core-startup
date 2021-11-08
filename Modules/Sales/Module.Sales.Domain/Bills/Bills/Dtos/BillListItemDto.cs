using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class BillListItemDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public GuidIdNameDto Supplier { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Bill, BillListItemDto>> Selector()
        {
            return x => new BillListItemDto
            {
                Id = x.Id,
                Number = x.Number,
                AmountDue = x.AmountDue,
                Supplier = x.ContactId != null ? new GuidIdNameDto
                {
                    Id = (Guid)x.ContactId,
                    Name = x.Contact.DisplayName
                } : null,
                IssueDate = x.IssueDate,
                Status = x.Status.ToString(),
                Total = x.GrandTotal,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
