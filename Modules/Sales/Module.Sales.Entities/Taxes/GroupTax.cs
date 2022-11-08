using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class GroupTax : RootEntity
    {
        public Guid TaxId { get; set; }
        public virtual TaxCode Tax { get; set; }

        public Guid GroupId { get; set; }
        public virtual TaxGroup Group { get; set; }
    }
}
