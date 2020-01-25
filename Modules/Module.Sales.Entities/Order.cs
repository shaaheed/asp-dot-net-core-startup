using Core.Interfaces.Entities;
using Module.Core.Entities;
using Module.Users.Entities;
using System;

namespace Module.Sales.Entities
{
    public class Order : BaseEntity
    {
        public long? CustomerId { get; set; }
        public User Customer { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
