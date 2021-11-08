using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    [IgnoredEntity]
    public abstract class InvoiceDocument : AbstractDocument
    {
        public string OrderNumber { get; set; }

        public string AdjustmentText { get; set; }
        public decimal AdjustmentAmount { get; set; }

        public bool Pinned { get; set; }
        public string Memo { get; set; }
        public decimal AmountDue { get; set; }
        public Status Status { get; set; }

        public DateTimeOffset? PaymentDueDate { get; set; }
    }
}
