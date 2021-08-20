using Module.Sales.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Contacts
{
    public class ContactListItemDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal TotalDueAmount { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Contact, ContactListItemDto>> Selector()
        {
            return x => new ContactListItemDto
            {
                Id = x.Id,
                CompanyName = x.CompanyName,
                DisplayName = x.DisplayName,
                Email = x.Email,
                Mobile = x.Mobile,
                Phone = x.Phone,
                Type = x.Type.ToString(),
                Address = x.BillingAddressId != null ? x.BillingAddress.AddressLine1 : null,
                CreatedAt = x.CreatedAt,
                TotalDueAmount = x.TotalDueAmount
            };
        }
    }
}
