using Module.Sales.Domain.Customers;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Bills
{
    public class BillDetailsDto
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public CustomerDto Vendor { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public IEnumerable<BillLineItemDto> Items { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
