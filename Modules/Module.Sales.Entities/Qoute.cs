using Core.Interfaces.Entities;
using Module.Core.Entities;
using Module.Users.Entities;
using System;

namespace Module.Sales.Entities
{
    public class Qoute : BaseEntity
    {
        public long? CustomerId { get; set; }
        public User Customer { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }
        public long CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
