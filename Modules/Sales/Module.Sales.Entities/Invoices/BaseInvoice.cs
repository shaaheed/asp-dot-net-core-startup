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
    }
}
