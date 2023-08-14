using Module.Systems.Entities;
using System;

namespace Module.Sales.Entities
{
    public class ItemSupplier : OrganizationCodeNameEntity
    {
        public string Memo { get; set; }

        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        public Guid SupplierId { get; set; }
        public virtual Contact Supplier { get; set; }

        public bool Preferred { get; set; }

    }
}
