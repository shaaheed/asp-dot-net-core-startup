using System;

namespace Module.Sales.Domain.Contacts
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public bool IsBusiness { get; set; }
        public bool IsIndividual { get; set; }

        public long Type { get; set; }
        public string DisplayName { get; set; }
        public string CompanyName { get; set; }

        public Guid? PrimaryPersonId { get; set; }
        public virtual Person PrimaryPerson { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public Guid? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        // Portal language
        public Guid? LanguageId { get; set; }
        public Language Language { get; set; }

        public Guid? BillingAddressId { get; set; }
        public virtual Address BillingAddress { get; set; }

        public Guid? ShippingAddressId { get; set; }
        public virtual Address ShippingAddress { get; set; }

        public static Expression<Func<Contact, ContactDto>> Selector()
        {
            return x => new ContactDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Description = x.Description,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
