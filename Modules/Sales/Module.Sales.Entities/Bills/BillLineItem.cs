using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class BillLineItem : BaseEntity
    {
        public Guid BillId { get; set; }
        public virtual Bill Bill { get; set; }
        public Guid LineItemId { get; set; }
        public LineItem LineItem { get; set; }

    }
}
