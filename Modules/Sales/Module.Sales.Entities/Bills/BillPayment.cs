using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class BillPayment : RootEntity
    {
        public Guid BillId { get; set; }
        public virtual Bill Bill { get; set; }

        public Guid PaymentId { get; set; }
    }
}
