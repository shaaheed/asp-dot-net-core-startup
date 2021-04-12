using Module.Sales.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class InvoicePrintDto
    {
        public InvoiceOrganizationPrintDto Organization { get; set; }
        public InvoiceCustomerPrintDto Customer { get; set; }
        public string Number { get; set; }
        public string IssueDate { get; set; }
        public IEnumerable<InvoicePrintLineItemDto> Items { get; set; }
        public decimal PaymentAmount { get; set; }
        public string AdjustmentText { get; set; }
        public decimal AdjustmentAmount { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Total { get; set; }
        public string Currency { get; set; }
        public string Note { get; set; }

        public static Expression<Func<Invoice, InvoicePrintDto>> Selector(decimal paymentAmount = 0)
        {
            return x => new InvoicePrintDto
            {
                Number = x.Code,
                AdjustmentAmount = x.AdjustmentAmount,
                AdjustmentText = x.AdjustmentText,
                AmountDue = x.AmountDue,
                Customer = x.CustomerId != null ? new InvoiceCustomerPrintDto
                {
                    Email = x.Customer.Email,
                    Name = x.Customer.DisplayName,
                    Mobile = x.Customer.Mobile
                } : null,
                IssueDate = x.IssueDate.ToLocalTime().ToString("MMMM dd, yyyy, hh:mm:ss tt"),
                Items = x.InvoiceLineItems.Select(y => new InvoicePrintLineItemDto
                {
                    Name = y.LineItem.Name,
                    Quantity = y.LineItem.Quantity,
                    Subtotal = y.LineItem.Subtotal,
                    Total = y.LineItem.Total,
                    UnitPrice = y.LineItem.UnitPrice,
                    Unit = y.LineItem.UnitId != null ? y.LineItem.Unit.Name : null
                }),
                PaymentAmount = paymentAmount,
                Total = x.GrandTotal
            };
        }
    }
}
