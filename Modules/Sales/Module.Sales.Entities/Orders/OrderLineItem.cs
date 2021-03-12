using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class OrderLineItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        public Guid LineItemId { get; set; }
        public virtual LineItem LineItem { get; set; }

    }
}
