using Msi.Data.Entity;
using System;

namespace Module.Payments.Entities
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public Guid PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        //public long PaymentAccount { get; set; }
        public string Memo { get; set; }
    }
}
