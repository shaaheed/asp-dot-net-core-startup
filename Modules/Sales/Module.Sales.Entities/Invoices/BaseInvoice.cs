using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    [IgnoredEntity]
    public class BaseInvoice : BaseQuote
    {
        public bool Pinned { get; set; }
        public string Memo { get; set; }
        public decimal AmountDue { get; set; }
        public Status Status { get; set; }

        public DateTimeOffset? PaymentDueDate { get; set; }

        public void AddPayment(decimal paymentAmount)
        {
            if(GrandTotal == paymentAmount)
            {
                // Full payment
                Status = Status.Paid;
                AmountDue = 0;
            }
            else if (GrandTotal > paymentAmount)
            {
                Status = Status.Due;
            }

            if (paymentAmount <= GrandTotal)
            {
                AmountDue = GrandTotal - paymentAmount;
            }
        }
    }
}
