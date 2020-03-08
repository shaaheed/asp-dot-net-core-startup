using Core.Interfaces.Entities;
using Module.Payments.Entities;

namespace Module.Sales.Entities
{
    public class InvoicePayment : BaseEntity
    {
        public long InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public long PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
