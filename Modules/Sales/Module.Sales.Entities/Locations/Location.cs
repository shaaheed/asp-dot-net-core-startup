using Msi.Data.Entity;
using Module.Systems.Entities;

namespace Module.Sales.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }

        public LocationType? Type { get; set; }

        public Guid? ParentId { get; set; }
        public Location Parent { get; set; }

        public string DocumentNumberPrefix { get; set; }
        public string TransactionNumberPrefix { get; set; }

        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
