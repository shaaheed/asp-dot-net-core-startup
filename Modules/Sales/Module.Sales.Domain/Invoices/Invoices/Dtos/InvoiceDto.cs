using Module.Sales.Domain.Contacts;
using Module.Sales.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string OrderNumber { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public ContactDto Contact { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset? PaymentDueDate { get; set; }
        public IEnumerable<LineItemDto> Items { get; set; }
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
                OrderNumber = x.OrderNumber,
                Reference = x.Reference,
                AdjustmentAmount = x.AdjustmentAmount,
                AdjustmentText = x.AdjustmentText,
                AmountDue = x.AmountDue,
                Contact = x.ContactId != null ? new ContactDto
                {
                    Id = (Guid)x.ContactId,
                    CompanyName = x.Contact.CompanyName,
                    Email = x.Contact.Email,
                    DisplayName = x.Contact.DisplayName,
                    Mobile = x.Contact.Mobile,
                    Phone = x.Contact.Phone,
                    Website = x.Contact.Website
                } : null,
                IssueDate = x.IssueDate,
                Memo = x.Memo,
                Note = x.Note,
                Status = x.Status.ToString(),
                PaymentDueDate = x.PaymentDueDate,
                PaymentAmount = paymentAmount,
                Total = x.GrandTotal
            };
        }
    }
}
