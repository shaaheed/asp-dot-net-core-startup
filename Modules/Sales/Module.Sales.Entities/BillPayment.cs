using Msi.Data.Entity;
using Module.Payments.Entities;
using System;

namespace Module.Sales.Entities
{
    public class BillPayment : BaseEntity
    {
        public Guid BillId { get; set; }
        public Bill Bill { get; set; }

        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
