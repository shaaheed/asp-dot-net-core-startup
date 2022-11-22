using Module.Organizations.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Organizations.Domain
{
    public class CreateOrganizationCurrencyCommand : ICommand<long>
    {

        public Guid OrganizationId { get; set; }
        public Guid CurrencyId { get; set; }
        public float ExchangeRate { get; set; }

        public virtual OrganizationCurrency Map(OrganizationCurrency entity = null)
        {
            entity = entity ?? new OrganizationCurrency();
            entity.OrganizationId = OrganizationId;
            entity.CurrencyId = CurrencyId;
            entity.ExchangeRate = ExchangeRate;
            return entity;
        }
    }
}
