using System;
using System.Collections.Generic;
using System.Linq;

namespace Module.Sales.Entities
{
    public class Quote : BaseQuote
    {
        public Quote()
        {
            QuoteLineItems = new HashSet<QuoteLineItem>();
        }

        public Guid? CustomerId { get; set; }
        public virtual Contact Customer { get; set; }

        public DateTimeOffset? ExpiresOn { get; set; }

        public virtual ICollection<QuoteLineItem> QuoteLineItems { get; set; }

        public void Calculate()
        {
            Calculate(QuoteLineItems.Select(x => x.LineItem));
        }

    }
}
