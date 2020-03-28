using Module.Core.Domain;
using System;

namespace Module.Sales.Domain.Qoutes
{
    public class QouteDto
    {
        public long Id { get; set; }
        public IdNameDto<long> Customer { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
    }
}
