using Core.Interfaces.Entities;

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
    public class PaymentProvider : BaseEntity
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}
