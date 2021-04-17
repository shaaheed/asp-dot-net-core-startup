using Module.Sales.Entities;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain
{
    public class InvoiceRequestDto
    {
        public string Number { get; set; }
        public Guid? ContactId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public string Note { get; set; }
        public string Memo { get; set; }
        public string AdjustmentText { get; set; }
        public decimal AdjustmentAmount { get; set; }
        public List<InvoiceLineItemRequestDto> Items { get; set; }

        public virtual Invoice Map(Invoice entity = null)
        {
            bool isNew = entity == null;
            entity = entity ?? new Invoice();
            if (isNew)
            {
                entity.Status = Status.Unpaid;
            }
            entity.Number = Number;
            entity.IssueDate = IssueDate ?? DateTimeOffset.UtcNow;
            entity.PaymentDueDate = PaymentDueDate ?? DateTimeOffset.UtcNow;
            entity.CustomerId = ContactId;
            entity.Note = Note;
            entity.Memo = Memo;
            entity.AdjustmentText = AdjustmentText;
            entity.AdjustmentAmount = AdjustmentAmount;

            return entity;
        }
    }
}
