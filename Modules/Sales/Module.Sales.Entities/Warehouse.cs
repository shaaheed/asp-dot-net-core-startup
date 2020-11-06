using Msi.Data.Entity;
using Module.Core.Entities;

namespace Module.Sales.Entities
{
    public class Warehouse : BaseEntity
    {

        public string Name { get; set; }


        public long? VendorId { get; set; }

        //public Vendor Vendor { get; set; }
        public long AddressId { get; set; }

        public Address Address { get; set; }
    }
}
