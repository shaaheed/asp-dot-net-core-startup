using Module.Sales.Entities;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain
{
    public class InvoiceRequestDto
    {
        public string Code { get; set; }
        public Guid? CustomerId { get; set; }
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
                entity.Status = InvoiceStatus.Unpaid;
            }
            entity.Code = Code;
            entity.IssueDate = IssueDate ?? DateTimeOffset.UtcNow;
            entity.PaymentDueDate = PaymentDueDate ?? DateTimeOffset.UtcNow;
            entity.CustomerId = CustomerId;
            entity.Note = Note;
            entity.Memo = Memo;
            entity.AdjustmentText = AdjustmentText;
            entity.AdjustmentAmount = AdjustmentAmount;

            return entity;
        }
    }
}
