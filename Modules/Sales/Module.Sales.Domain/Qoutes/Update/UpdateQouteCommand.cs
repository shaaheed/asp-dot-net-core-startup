using Msi.Mediator.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Qoutes
{
    public class UpdateQouteCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public List<UpdateQouteLineItemDto> Items { get; set; }
    }
}
