using Msi.Mediator.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Bills
{
    public class UpdateBillCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public Guid? VendorId { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Note { get; set; }
        public List<UpdateBillLineItemDto> Items { get; set; }
    }
}
