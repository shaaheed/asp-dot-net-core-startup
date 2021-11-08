using System;
using System.Collections.Generic;

namespace Module.Sales.Entities
{
    public class Quote : AbstractDocument
    {
        public Quote()
        {
            QuoteLineItems = new HashSet<QuoteLineItem>();
        }

        public Guid? CustomerId { get; set; }
        public virtual Contact Customer { get; set; }

        public DateTimeOffset? ExpiresOn { get; set; }

        public virtual ICollection<QuoteLineItem> QuoteLineItems { get; set; }

    }
}
