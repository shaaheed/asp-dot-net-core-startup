using Module.Sales.Entities;
using Module.Systems.Domain;
using Module.Systems.Domain.Persons;
using Msi.Mediator.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Contacts
{
    public class CreateContactCommand : ICommand<long>
    {
        public bool IsBusiness { get; set; }
        public bool IsIndividual { get; set; }

        public ContactType Type { get; set; }
        public string DisplayName { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<CreatePersonCommand> ContactPersons { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public Guid? CurrencyId { get; set; }
        public Guid? LanguageId { get; set; }

        public virtual CreateAddressCommand BillingAddress { get; set; }
        public virtual CreateAddressCommand ShippingAddress { get; set; }

        public virtual Contact Map(Contact entity = null)
        {
            entity = entity ?? new Contact();
            entity.IsBusiness = IsBusiness;
            entity.IsIndividual = IsIndividual;
            entity.Type = Type;

            entity.DisplayName = DisplayName;
            entity.CompanyName = CompanyName;
            entity.Phone = Phone;
            entity.Mobile = Mobile;
            entity.Email = Email;

            entity.Website = Website;
            entity.CurrencyId = CurrencyId;
            entity.LanguageId = LanguageId;
            return entity;
        }
    }
}
