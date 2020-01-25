using Core.Infrastructure.Commands;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.InvoicePayments
{
    public class UpdateInvoicePaymentCommand : ICommand<long>
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
    }
}
