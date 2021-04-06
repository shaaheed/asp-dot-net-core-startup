using Module.Payments.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Payments.Domain
{
    public class PaymentMethodDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<PaymentMethod, PaymentMethodDto>> Selector()
        {
            return x => new PaymentMethodDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
