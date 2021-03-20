using Module.Sales.Domain.Contacts;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Invoices
{
    public class InvoiceDetailsDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public ContactDto Customer { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset PaymentDueDate { get; set; }
        public IEnumerable<InvoiceLineItemDto> Items { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Note { get; set; }
        public string Memo { get; set; }
    }
}
