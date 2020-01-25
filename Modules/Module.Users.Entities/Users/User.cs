using Core.Interfaces.Entities;
using Module.Core.Entities;
using System;
using System.Collections.Generic;

namespace Module.Users.Entities
{
    public class User : BaseEntity
    {

        public User()
        {
            UserGroupAssociations = new HashSet<UserGroupAssociation>();
            UserResources = new HashSet<UserResource>();
            UserResourceGroups = new HashSet<UserResourceGroup>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
        public long? AddressId { get; set; }
        public Address Address { get; set; }

        public string Contact { get; set; }

        public long? CurrencyId { get; set; }
        public Currency Currency { get; set; }

        //public long? CountryId { get; set; }
        //public Country Country { get; set; }

        //public long? LanguageId { get; set; }
        //public Language Language { get; set; }

        public ICollection<UserGroupAssociation> UserGroupAssociations { get; protected set; }
        public ICollection<UserResource> UserResources { get; protected set; }
        public ICollection<UserResourceGroup> UserResourceGroups { get; protected set; }
    }
}
