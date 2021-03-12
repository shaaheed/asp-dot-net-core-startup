using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class LineItemTax : BaseEntity
    {
        public Guid LineItemId { get; set; }
        public virtual LineItem LineItem { get; set; }

        public Guid TaxId { get; set; }
        public virtual Tax Tax { get; set; }
    }
}
