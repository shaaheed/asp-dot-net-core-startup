using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Contacts
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public bool IsBusiness { get; set; }
        public bool IsIndividual { get; set; }

        public string Type { get; set; }
        public string DisplayName { get; set; }
        public string CompanyName { get; set; }

        public PersonDto PrimaryPerson { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public GuidCodeNameDto Currency { get; set; }
        public GuidIdNameDto Language { get; set; }

        public virtual AddressDto BillingAddress { get; set; }
        public virtual AddressDto ShippingAddress { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Contact, ContactDto>> Selector()
        {
            return x => new ContactDto
            {
                Id = x.Id,
                Type = x.Type.ToString(),
                Email = x.Email,
                IsBusiness = x.IsBusiness,
                IsIndividual = x.IsIndividual,
                CompanyName = x.CompanyName,
                DisplayName = x.DisplayName,
                Mobile = x.Mobile,
                Phone = x.Phone,
                Website = x.Website,
                Currency = x.CurrencyId != null ? new GuidCodeNameDto
                {
                    Id = x.Currency.Id,
                    Code = x.Currency.Symbol,
                    Name = x.Currency.Name
                } : null,
                Language = x.LanguageId != null ? new GuidIdNameDto
                {
                    Id = x.Language.Id,
                    Name = x.Language.Name
                } : null,
                BillingAddress = x.BillingAddressId != null ? new AddressDto
                {
                    Id = x.BillingAddress.Id,
                    AddressLine1 = x.BillingAddress.AddressLine1,
                    AddressLine2 = x.BillingAddress.AddressLine2,
                    AddressLine3 = x.BillingAddress.AddressLine3,
                    AddressLine4 = x.BillingAddress.AddressLine4,
                    AddressLine5 = x.BillingAddress.AddressLine5,
                    Attention = x.BillingAddress.Attention,
                    City = x.BillingAddress.City,
                    ContactName = x.BillingAddress.ContactName,
                    Country = x.BillingAddress.CountryId != null ? new GuidIdNameDto
                    {
                        Id = x.BillingAddress.Country.Id,
                        Name = x.BillingAddress.Country.Name
                    } : null,
                    District = x.BillingAddress.DistrictId != null ? new GuidIdNameDto
                    {
                        Id = x.BillingAddress.District.Id,
                        Name = x.BillingAddress.District.Name
                    } : null,
                    Phone = x.BillingAddress.Phone,
                    ZipCode = x.BillingAddress.ZipCode,
                    StateOrProvince = x.BillingAddress.StateOrProvinceId != null ? new GuidIdNameDto
                    {
                        Id = x.BillingAddress.StateOrProvince.Id,
                        Name = x.BillingAddress.StateOrProvince.Name
                    } : null
                } : null,

                ShippingAddress = x.ShippingAddressId != null ? new AddressDto
                {
                    Id = x.ShippingAddress.Id,
                    AddressLine1 = x.ShippingAddress.AddressLine1,
                    AddressLine2 = x.ShippingAddress.AddressLine2,
                    AddressLine3 = x.ShippingAddress.AddressLine3,
                    AddressLine4 = x.ShippingAddress.AddressLine4,
                    AddressLine5 = x.ShippingAddress.AddressLine5,
                    Attention = x.ShippingAddress.Attention,
                    City = x.ShippingAddress.City,
                    ContactName = x.ShippingAddress.ContactName,
                    Country = x.ShippingAddress.CountryId != null ? new GuidIdNameDto
                    {
                        Id = x.ShippingAddress.Country.Id,
                        Name = x.ShippingAddress.Country.Name
                    } : null,
                    District = x.ShippingAddress.DistrictId != null ? new GuidIdNameDto
                    {
                        Id = x.ShippingAddress.District.Id,
                        Name = x.ShippingAddress.District.Name
                    } : null,
                    Phone = x.ShippingAddress.Phone,
                    ZipCode = x.ShippingAddress.ZipCode,
                    StateOrProvince = x.ShippingAddress.StateOrProvinceId != null ? new GuidIdNameDto
                    {
                        Id = x.ShippingAddress.StateOrProvince.Id,
                        Name = x.ShippingAddress.StateOrProvince.Name
                    } : null
                } : null,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
