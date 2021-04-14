using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    [IgnoredEntity]
    public class ProductTax : RootEntity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid TaxId { get; set; }
        public virtual Tax Tax { get; set; }
    }
}
