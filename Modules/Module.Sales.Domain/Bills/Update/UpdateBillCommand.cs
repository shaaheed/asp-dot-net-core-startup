using Core.Infrastructure.Commands;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Bills
{
    public class UpdateBillCommand : ICommand<long>
    {
        public long Id { get; set; }
        public long? VendorId { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Note { get; set; }
        public List<UpdateBillLineItemDto> Items { get; set; }
    }
}
