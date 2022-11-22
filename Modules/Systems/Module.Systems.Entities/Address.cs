using Msi.Data.Entity;
using System;

namespace Module.Systems.Entities
{
    public class Address : BaseEntity
    {
        public Address() { }

        public Address(Guid id)
        {
            Id = id;
        }

        public string Attention { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string AddressLine5 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string WebLink { get; set; }

        public Guid? DistrictId { get; set; }
        public virtual District District { get; set; }
        
        public Guid? StateOrProvinceId { get; set; }
        public virtual StateOrProvince StateOrProvince { get; set; }

        public Guid? CountryId { get; set; }
        public virtual Country Country { get; set; }

        // public TimeZone TimeZone { get; set; }

    }
}
