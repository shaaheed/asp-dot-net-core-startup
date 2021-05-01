using System;

namespace Module.Sales.Domain
{
    public class CreateBillPaymentCommand : BaseCreateInvoicePaymentCommand
    {
        public Guid BillId { get; set; }
    }
}
