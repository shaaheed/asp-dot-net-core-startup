using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class QuoteLineItem : RootEntity
    {
        public Guid QuoteId { get; set; }
        public virtual Quote Quote { get; set; }

        public Guid LineItemId { get; set; }
        public virtual LineItem LineItem { get; set; }

    }
}
