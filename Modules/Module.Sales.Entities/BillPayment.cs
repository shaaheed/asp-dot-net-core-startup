using Core.Interfaces.Entities;
using Module.Payments.Entities;

namespace Module.Sales.Entities
{
    public class BillPayment : BaseEntity
    {
        public long BillId { get; set; }
        public Bill Bill { get; set; }

        public long PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
