using Module.Systems.Entities;
using System;

namespace Module.Systems.Domain
{
    public class CreateAddressRequest
    {
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

        public Guid? DistrictId { get; set; }
        public Guid? StateOrProvinceId { get; set; }
        public Guid? CountryId { get; set; }

        public virtual Address Map(Address entity = null)
        {
            entity = entity ?? new Address();
            entity.Attention = Attention;
            entity.ContactName = ContactName;
            entity.Phone = Phone;
            entity.AddressLine1 = AddressLine1;
            entity.AddressLine2 = AddressLine2;
            entity.AddressLine3 = AddressLine3;
            entity.AddressLine4 = AddressLine4;
            entity.AddressLine5 = AddressLine5;
            entity.City = City;
            entity.ZipCode = ZipCode;

            entity.DistrictId = DistrictId;
            entity.StateOrProvinceId = StateOrProvinceId;
            entity.CountryId = CountryId;
            return entity;
        }
    }
}
