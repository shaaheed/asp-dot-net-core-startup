using Module.Sales.Domain.Customers;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.InvoicePayments
{
    public class InvoicePaymentDetailsDto
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public CustomerDto Customer { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset PaymentDueDate { get; set; }
    }
}
