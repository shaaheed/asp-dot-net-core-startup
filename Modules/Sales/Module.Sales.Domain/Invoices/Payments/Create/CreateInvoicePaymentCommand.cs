using System;

namespace Module.Sales.Domain
{
    public class CreateInvoicePaymentCommand : BaseCreateInvoicePaymentCommand
    {
        public Guid InvoiceId { get; set; }
    }
}
