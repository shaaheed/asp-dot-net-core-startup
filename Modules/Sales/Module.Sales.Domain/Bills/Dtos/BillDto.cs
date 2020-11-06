using Module.Core.Domain;
using System;

namespace Module.Sales.Domain.Bills
{
    public class BillDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public IdNameDto<Guid> Vendor { get; set; }
        public decimal AmountDue { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
    }
}
