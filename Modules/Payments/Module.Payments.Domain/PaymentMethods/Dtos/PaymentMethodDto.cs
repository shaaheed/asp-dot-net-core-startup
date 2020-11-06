using System;

namespace Module.Payments.Domain
{
    public class PaymentMethodDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
