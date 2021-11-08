using Module.Payments.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Payments.Domain
{
    public class CreatePaymentCommand : ICreateCommand<Payment, Guid>
    {
        public string Number { get; set; }

        public Guid? CustomerId { get; set; }
        public string CustomerName { get; set; }

        public decimal Amount { get; set; }
        public string Reference { get; set; }

        public Guid? PaymentMethodId { get; set; }
        public Guid? AccountId { get; set; }

        public Guid? CurrencyId { get; set; }
        public float CurrencyExchangeRate { get; set; }

        public Guid DocumentId { get; set; }
        public string DocumentName { get; set; }

        public DateTimeOffset PaymentDate { get; set; }
        public string Memo { get; set; }

        public Payment Map(Payment entity = null)
        {
            entity = entity ?? new Payment();
            entity.Number = Number;
            entity.CustomerId = CustomerId;
            entity.CustomerName = CustomerName;
            entity.Amount = Amount;
            entity.Reference = Reference;
            entity.PaymentMethodId = PaymentMethodId;
            entity.CurrencyId = CurrencyId;
            entity.CurrencyExchangeRate = CurrencyExchangeRate;
            entity.AccountId = AccountId;
            entity.DocumentId = DocumentId;
            entity.DocumentName = DocumentName;
            entity.PaymentDate = PaymentDate;
            entity.Memo = Memo;
            return entity;
        }
    }
}
