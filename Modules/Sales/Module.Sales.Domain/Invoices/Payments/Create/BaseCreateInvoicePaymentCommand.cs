using Module.Payments.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class BaseCreateInvoicePaymentCommand : ICommand<long>
    {
        public string Number { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public Guid? PaymentMethodId { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        public string Memo { get; set; }

        public virtual Payment Map(Payment entity = null)
        {
            entity = entity ?? new Payment();
            entity.Number = Number;
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
