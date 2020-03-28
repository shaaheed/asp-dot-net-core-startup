using Core.Infrastructure.Commands;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Qoutes
{
    public class UpdateQouteCommand : ICommand<long>
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public List<UpdateQouteLineItemDto> Items { get; set; }
    }
}
