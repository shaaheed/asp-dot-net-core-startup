using Core.Infrastructure.Commands;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.InvoicePayments
{
    public class CreateInvoicePaymentCommand : ICommand<long>
    {
        public long? CustomerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
    }
}
