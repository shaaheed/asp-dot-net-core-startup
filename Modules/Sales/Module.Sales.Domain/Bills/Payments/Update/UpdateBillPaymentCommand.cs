using System;

namespace Module.Sales.Domain
{
    public class UpdateBillPaymentCommand : CreateBillPaymentCommand
    {
        public Guid Id { get; set; }
    }
}
