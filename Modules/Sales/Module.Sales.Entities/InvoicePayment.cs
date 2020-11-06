using Msi.Data.Entity;
using Module.Payments.Entities;
using System;

namespace Module.Sales.Entities
{
    public class InvoicePayment : BaseEntity
    {
        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
