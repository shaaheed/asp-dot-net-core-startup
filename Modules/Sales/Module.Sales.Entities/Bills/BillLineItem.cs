using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class BillLineItem : RootEntity
    {
        public Guid BillId { get; set; }
        public virtual Bill Bill { get; set; }
        public Guid LineItemId { get; set; }
        public LineItem LineItem { get; set; }

    }
}
