using Msi.Data.Entity;
using Module.Core.Entities;
using System;

namespace Module.Sales.Entities
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; }

        public Guid? VendorId { get; set; }

        //public Vendor Vendor { get; set; }
        public Guid AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}
