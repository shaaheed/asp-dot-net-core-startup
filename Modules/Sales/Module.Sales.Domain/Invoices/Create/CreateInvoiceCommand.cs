﻿using Msi.Mediator.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Invoices
{
    public class CreateInvoiceCommand : ICommand<long>
    {
        public Guid? CustomerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public string Note { get; set; }
        public string Memo { get; set; }
        public List<CreateInvoiceLineItemDto> Items { get; set; }
    }
}