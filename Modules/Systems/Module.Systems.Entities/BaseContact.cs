using Module.Systems.Entities;
using Msi.Data.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Sales.Entities
{
    [IgnoredEntity]
    public class BaseContact : OrganizationEntity
    {
        public bool IsBusiness { get; set; }
        public bool IsIndividual { get; set; }

        public string DisplayName { get; set; }
        public string CompanyName { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string  Website { get; set; }

        public Guid? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Balance { get; set; }

        [Column(TypeName = "decimal(18,4)")]
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
