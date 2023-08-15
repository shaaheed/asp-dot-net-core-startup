using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class ItemGroup : OrganizationEntity
    {
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
