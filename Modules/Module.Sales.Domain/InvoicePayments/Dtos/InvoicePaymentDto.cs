using Module.Sales.Domain.Invoices;
using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class InvoicePaymentDto
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public InvoiceCustomerDto Customer { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
    }
}
