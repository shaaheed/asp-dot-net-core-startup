﻿using Core.Interfaces.Entities;

namespace Module.Payments.Entities
{
    /// <summary>
    /// 1. Bank payment
    /// 2. Cash
    /// 3. Cheque
    /// 4. Credit Card
    /// 5. Paypal
    /// 6. Other etc
    /// </summary>
    public class PaymentMethod : BaseEntity
    {
        public PaymentMethod()
        {

        }
        public PaymentMethod(long id)
        {
            Id = id;
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsEnable { get; set; }
        public long? PaymentProviderId { get; set; }
        public PaymentProvider PaymentProvider { get; set; }
    }
}
