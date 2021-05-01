using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class BillPaymentDto : BaseInvoicePaymentDto
    {
        public Guid BillId { get; set; }

        public static Expression<Func<BillPayment, BillPaymentDto>> Selector()
        {
            return x => new BillPaymentDto
            {
                Id = x.Id,
                BillId = x.BillId,
                PaymentId = x.PaymentId,
                Amount = x.Payment.Amount,
                CustomerId = x.Payment.CustomerId,
                Memo = x.Payment.Memo,
                Reference = x.Payment.Reference,
                PaymentDate = x.Payment.PaymentDate,
                PaymentMethod = x.Payment.PaymentMethodId != null ? new GuidIdNameDto
                {
                    Id = (Guid)x.Payment.PaymentMethodId,
                    Name = x.Payment.PaymentMethod.Name
                } : null,
                PaymentAccountId = x.Payment.PaymentAccountId,
                Number = x.Payment.Number
            };
        }
    }
}
