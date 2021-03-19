using Module.Systems.Domain;
using Module.Sales.Domain.Customers;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Qoutes
{
    public class QouteDetailsDto
    {
        public Guid Id { get; set; }
        public CustomerDto Customer { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public string Memo { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }
        public IdNameDto<Guid> Currency { get; set; }
        public int TotalConvertedInvoice { get; set; }
        public IEnumerable<QouteLineItemDto> Items { get; set; }
    }
}
