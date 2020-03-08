using Core.Interfaces.Data;
using Module.Payments.Entities;
using System.Collections.Generic;

namespace Module.Payments.Data
{
    public class PaymentMethodSeed : ISeed<PaymentMethod>
    {
        public IEnumerable<PaymentMethod> GetSeeds()
        {
            return new List<PaymentMethod>
            {
                new PaymentMethod(1) { Name = "Bank payment", Code = "bank_payment", IsEnable = true },
                new PaymentMethod(2) { Name = "Cash", Code = "cash", IsEnable = true },
                new PaymentMethod(3) { Name = "Cheque", Code = "cheque", IsEnable = true }
            };
        }
    }
}
