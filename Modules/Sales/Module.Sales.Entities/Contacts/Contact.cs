using Module.Systems.Entities;
using Msi.Data.Entity;
using Msi.Utilities.Filter;
using System;

namespace Module.Sales.Entities
{
    public class Contact : OrganizationEntity
    {
        public bool IsBusiness { get; set; }
        public bool IsIndividual { get; set; }

        [Searchable]
        public ContactType Type { get; set; }
        public string DisplayName { get; set; }
        public string CompanyName { get; set; }

        public Guid? PrimaryPersonId { get; set; }
        public virtual Person PrimaryPerson { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string  Website { get; set; }

        public Guid? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        public decimal Balance { get; set; }
        public decimal? CreditLimit { get; set; }

        // Portal language
        public Guid? LanguageId { get; set; }
        public Language Language { get; set; }

        public Guid? BillingAddressId { get; set; }
        public virtual Address BillingAddress { get; set; }

        public Guid? ShippingAddressId { get; set; }
        public virtual Address ShippingAddress { get; set; }

    }
}
