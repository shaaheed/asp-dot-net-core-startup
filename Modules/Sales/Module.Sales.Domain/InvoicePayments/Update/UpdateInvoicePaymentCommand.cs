using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class UpdateInvoicePaymentCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
    }
}
