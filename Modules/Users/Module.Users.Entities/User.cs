using Module.Systems.Entities;
using Msi.Data.Entity;
using System;

namespace Module.Accounts.Entities
{
    public class User : BaseEntity, IUser<Guid>
    {
        public bool TwoFactorEnabled { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string UserName { get; set; }
       
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }

        // Gets or sets the number of failed login attempts for the current user.
        public int AccessFailedCount { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Website { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }

        public string Contact { get; set; }

        public Guid? CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public Guid? CountryId { get; set; }
        public Country Country { get; set; }

        public Guid? LanguageId { get; set; }
        public Language Language { get; set; }

        public Guid? OrganizationId { get; set; }
    }
}
