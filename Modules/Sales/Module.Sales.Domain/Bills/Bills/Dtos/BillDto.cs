using Module.Sales.Domain.Contacts;
using Module.Sales.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class BillDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string OrderNumber { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public ContactDto Supplier { get; set; }
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

        public static Expression<Func<Bill, BillDto>> Selector(decimal paymentAmount = 0)
        {
            return x => new BillDto
            {
                Id = x.Id,
                Number = x.Number,
                OrderNumber = x.OrderNumber,
                Reference = x.Reference,
                AdjustmentAmount = x.AdjustmentAmount,
                AdjustmentText = x.AdjustmentText,
                AmountDue = x.AmountDue,
                Supplier = x.SupplierId != null ? new ContactDto
                {
                    Id = (Guid)x.SupplierId,
                    CompanyName = x.Supplier.CompanyName,
                    Email = x.Supplier.Email,
                    DisplayName = x.Supplier.DisplayName,
                    Mobile = x.Supplier.Mobile,
                    Phone = x.Supplier.Phone,
                    Website = x.Supplier.Website
                } : null,
                IssueDate = x.IssueDate,
                Memo = x.Memo,
                Note = x.Note,
                Status = x.Status.ToString(),
                PaymentDueDate = x.PaymentDueDate,
                //Items = x.BillLineItems.Select(y => new BillLineItemDto
                //{
                //    Id = y.Id,
                //    Name = y.LineItem.Name,
                //    Description = y.LineItem.Description,
                //    ProductId = y.LineItem.ProductId,
                //    Quantity = y.LineItem.Quantity,
                //    Subtotal = y.LineItem.Subtotal,
                //    Total = y.LineItem.Total,
                //    UnitPrice = y.LineItem.UnitPrice,
                //    Note = y.LineItem.Note,
                //    Unit = y.LineItem.UnitId != null ? new GuidCodeNameDto
                //    {
                //        Id = (Guid)y.LineItem.UnitId,
                //        Code = y.LineItem.Unit.Symbol,
                //        Name = y.LineItem.Unit.Name
                //    } : null
                //}),
                PaymentAmount = paymentAmount,
                Total = x.GrandTotal
            };
        }
    }
}
