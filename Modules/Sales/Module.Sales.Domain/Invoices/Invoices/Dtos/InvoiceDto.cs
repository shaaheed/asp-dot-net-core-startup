using Module.Sales.Domain.Contacts;
using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public ContactDto Customer { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset? PaymentDueDate { get; set; }
        public IEnumerable<InvoiceLineItemDto> Items { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Note { get; set; }
        public string Memo { get; set; }

        public string AdjustmentText { get; set; }
        public decimal AdjustmentAmount { get; set; }

        public static Expression<Func<Invoice, InvoiceDto>> Selector(decimal paymentAmount = 0)
        {
            return x => new InvoiceDto
            {
                Id = x.Id,
                Number = x.Number,
                AdjustmentAmount = x.AdjustmentAmount,
                AdjustmentText = x.AdjustmentText,
                AmountDue = x.AmountDue,
                Customer = x.CustomerId != null ? new ContactDto
                {
                    Id = (Guid)x.CustomerId,
                    CompanyName = x.Customer.CompanyName,
                    Email = x.Customer.Email,
                    DisplayName = x.Customer.DisplayName,
                    Mobile = x.Customer.Mobile,
                    Phone = x.Customer.Phone,
                    Website = x.Customer.Website
                } : null,
                IssueDate = x.IssueDate,
                Memo = x.Memo,
                Note = x.Note,
                Status = x.Status.ToString(),
                PaymentDueDate = x.PaymentDueDate,
                Items = x.InvoiceLineItems.Select(y => new InvoiceLineItemDto
                {
                    Id = y.Id,
                    Name = y.LineItem.Name,
                    Description = y.LineItem.Description,
                    ProductId = y.LineItem.ProductId,
                    Quantity = y.LineItem.Quantity,
                    Subtotal = y.LineItem.Subtotal,
                    Total = y.LineItem.Total,
                    UnitPrice = y.LineItem.UnitPrice,
                    Note = y.LineItem.Note,
                    Unit = y.LineItem.UnitId != null ? new GuidCodeNameDto
                    {
                        Id = (Guid)y.LineItem.UnitId,
                        Code = y.LineItem.Unit.Symbol,
                        Name = y.LineItem.Unit.Name
                    } : null
                }),
                PaymentAmount = paymentAmount,
                Total = x.GrandTotal
            };
        }
    }
}
