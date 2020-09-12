using Microsoft.AspNetCore.Identity;
using Module.Core.Entities;
using Msi.Data.Entity;
using Msi.Mediator.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Module.Users.Entities
{
    public class User : IdentityUser<long>, IEntity, IAuditableEntity<long>, IEventAggregate
    {
        public User()
        {
            PendingEvents = new Queue<IEvent>();
        }

        public void Append(IEvent @event)
        {
            PendingEvents.Enqueue(@event);
        }

        [JsonIgnore]
        public Queue<IEvent> PendingEvents { get; private set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Website { get; set; }
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

        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? OrganizationId { get; set; }
    }
}
