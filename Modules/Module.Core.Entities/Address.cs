using Core.Interfaces.Entities;

namespace Module.Core.Entities
{
    public class Address : BaseEntity
    {
        public Address() { }

        public Address(long id)
        {
            Id = id;
        }

        public string ContactName { get; set; }

        public string Phone { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string AddressLine5 { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public long? DistrictId { get; set; }

        public District District { get; set; }

        public long StateOrProvinceId { get; set; }

        public StateOrProvince StateOrProvince { get; set; }

        public long? CountryId { get; set; }

        public Country Country { get; set; }

    }
}
