using Core.Infrastructure.Commands;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Invoices
{
    public class UpdateInvoiceCommand : ICommand<long>
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public List<UpdateInvoiceLineItemDto> Items { get; set; }
    }
}
