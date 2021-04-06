using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class UpdateInvoicePaymentCommand : CreateInvoicePaymentCommand
    {
        public Guid Id { get; set; }
    }
}
