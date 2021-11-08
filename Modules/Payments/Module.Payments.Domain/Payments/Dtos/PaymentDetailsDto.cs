using Module.Payments.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Payments.Domain
{
    public class PaymentDetailsDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }

        public Guid? PaymentMethodId { get; set; }

        public Guid DocumentId { get; set; }
        public string DocumentName { get; set; }

        public DateTimeOffset PaymentDate { get; set; }

        public Guid? AccountId { get; set; }

        public Guid? CustomerId { get; set; }
        public string CustomerName { get; set; }

        public Guid? CurrencyId { get; set; }
        public float CurrencyExchangeRate { get; set; }

        public string Memo { get; set; }

        public static Expression<Func<Payment, PaymentDetailsDto>> Selector()
        {
            return x => new PaymentDetailsDto
            {
                Id = x.Id,
                Number = x.Number,
                Amount = x.Amount,
                Reference = x.Reference,
                PaymentMethodId = x.PaymentMethodId,
                DocumentId = x.DocumentId,
                DocumentName = x.DocumentName,
                PaymentDate = x.PaymentDate,
                AccountId = x.AccountId,
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                CurrencyId = x.CurrencyId,
                Memo = x.Memo,
                CurrencyExchangeRate = x.CurrencyExchangeRate
            };
        }
    }
}
