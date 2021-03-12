using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class InvoicePayment : BaseEntity
    {
        public Guid InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }

        public Guid PaymentId { get; set; }
    }
}
