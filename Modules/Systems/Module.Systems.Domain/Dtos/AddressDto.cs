using System;

namespace Module.Systems.Domain
{
    public class AddressDto
    {
        public Guid Id { get; set; }
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

        public GuidIdNameDto District { get; set; }
        public GuidIdNameDto StateOrProvince { get; set; }
        public GuidIdNameDto Country { get; set; }
    }
}
