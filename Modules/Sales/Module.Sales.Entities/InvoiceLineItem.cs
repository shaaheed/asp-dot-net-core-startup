using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class InvoiceLineItem : BaseEntity
    {
        public Guid InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public Guid LineItemId { get; set; }
        public LineItem LineItem { get; set; }

    }
}
