using Module.Payments.Entities;
using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class InvoicePayment : RootEntity
    {
        public Guid InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }

        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
