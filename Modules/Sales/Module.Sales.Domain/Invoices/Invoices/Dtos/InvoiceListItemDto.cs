using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class InvoiceListItemDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public GuidIdNameDto Customer { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Invoice, InvoiceListItemDto>> Selector()
        {
            return x => new InvoiceListItemDto
            {
                Id = x.Id,
                Code = x.Code,
                AmountDue = x.AmountDue,
                Customer = x.CustomerId != null ? new GuidIdNameDto
                {
                    Id = (Guid)x.CustomerId,
                    Name = x.Customer.DisplayName
                } : null,
                IssueDate = x.IssueDate,
                Status = x.Status.ToString(),
                Total = x.GrandTotal,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
