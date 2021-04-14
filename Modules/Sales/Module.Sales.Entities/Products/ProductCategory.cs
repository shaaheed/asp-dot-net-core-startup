using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class ProductCategory : RootEntity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
