using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class QouteLineItem : BaseEntity
    {
        public Guid QouteId { get; set; }
        public virtual Qoute Qoute { get; set; }
        public Guid LineItemId { get; set; }
        public LineItem LineItem { get; set; }

    }
}
