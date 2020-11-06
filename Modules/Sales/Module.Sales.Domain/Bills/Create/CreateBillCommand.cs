using Msi.Mediator.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Bills
{
    public class CreateBillCommand : ICommand<long>
    {
        public Guid? CustomerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Note { get; set; }
        public List<CreateBillLineItemDto> Items { get; set; }
    }
}
