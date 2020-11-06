using Module.Core.Domain;
using System;

namespace Module.Sales.Domain.Qoutes
{
    public class QouteDto
    {
        public Guid Id { get; set; }
        public IdNameDto<Guid> Customer { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset IssueDate { get; set; }
    }
}
