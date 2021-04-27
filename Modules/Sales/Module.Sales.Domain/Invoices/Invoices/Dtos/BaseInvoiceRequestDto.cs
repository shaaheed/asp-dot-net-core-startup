using System;

namespace Module.Sales.Domain
{
    public abstract class BaseInvoiceRequestDto
    {
        public string Number { get; set; }
        public Guid? ContactId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public string Note { get; set; }
        public string Memo { get; set; }
        public string AdjustmentText { get; set; }
        public decimal AdjustmentAmount { get; set; }
    }
}
