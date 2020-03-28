using Core.Infrastructure.Commands;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Qoutes
{
    public class CreateQouteCommand : ICommand<long>
    {
        public long? CustomerId { get; set; }
        public string Memo { get; set; }
        public long? CurrencyId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }
        public List<CreateQouteLineItemDto> Items { get; set; }
    }
}
