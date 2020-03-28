using Module.Core.Domain;
using System;

namespace Module.Sales.Domain.Invoices
{
    public class InvoiceDto
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public IdNameDto<long> Customer { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
    }
}
