using Msi.Data.Entity;
using System;

namespace Module.Payments.Entities
{
    public class Payment : BaseEntity
    {
        public string Number { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }

        public Guid? PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }

        public Guid DocumentId { get; set; }
        public string DocumentName { get; set; }

        public DateTimeOffset PaymentDate { get; set; }

        public Guid? AccountId { get; set; }

        public Guid? CustomerId { get; set; }
        public string CustomerName { get; set; }

        public Guid? CurrencyId { get; set; }
        public float CurrencyExchangeRate { get; set; }

        public string Memo { get; set; }
    }
}
