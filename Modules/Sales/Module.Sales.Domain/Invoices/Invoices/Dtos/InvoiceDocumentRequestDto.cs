using Module.Sales.Entities;
using System;

namespace Module.Sales.Domain
{
    public abstract class InvoiceDocumentRequestDto<TEntity> where TEntity : InvoiceDocument, new()
    {
        public string Reference { get; set; }
        public string OrderNumber { get; set; }
        public string Number { get; set; }
        public Guid? ContactId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public string Note { get; set; }
        public string Memo { get; set; }
        public string AdjustmentText { get; set; }
        public decimal AdjustmentAmount { get; set; }

        public virtual TEntity Map(TEntity entity = null)
        {
            bool isNew = entity == null;
            entity = entity ?? new TEntity();
            if (isNew)
            {
                entity.Status = Status.Unpaid;
            }
            entity.Reference = Reference;
            entity.Number = Number;
            entity.IssueDate = IssueDate ?? DateTimeOffset.UtcNow;
            entity.PaymentDueDate = PaymentDueDate ?? DateTimeOffset.UtcNow;
            entity.Note = Note;
            entity.Memo = Memo;
            entity.Reference = Reference;
            entity.OrderNumber = OrderNumber;
            entity.ContactId = ContactId;
            entity.AdjustmentText = AdjustmentText;
            entity.AdjustmentAmount = AdjustmentAmount;

            return entity;
        }
    }
}
