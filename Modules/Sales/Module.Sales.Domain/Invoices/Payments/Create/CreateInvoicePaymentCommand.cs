using Module.Payments.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class CreateInvoicePaymentCommand : ICommand<long>
    {
        public Guid InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public Guid? PaymentMethodId { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        public string Memo { get; set; }

        public virtual Payment Map(Payment entity = null)
        {
            entity = entity ?? new Payment();
            entity.Amount = Amount;
            entity.Memo = Memo;
            entity.Reference = Reference;
            entity.PaymentMethodId = PaymentMethodId;
            entity.CustomerId = CustomerId;
            entity.PaymentDate = PaymentDate;
            return entity;
        }
    }
}
