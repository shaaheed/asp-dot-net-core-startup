using Module.Organizations.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Organizations.Domain
{
    public class CreateOrganizationCommand : ICommand<long>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public bool IsDefault { get; set; }
        public Guid? CurrencyId { get; set; }

        public virtual Organization Map(Organization entity = null)
        {
            entity = entity ?? new Organization();
            entity.Name = Name;
            entity.Email = Email;
            entity.IsDefault = IsDefault;
            entity.Owner = Owner;
            entity.CurrencyId = CurrencyId;
            return entity;
        }
    }
}
