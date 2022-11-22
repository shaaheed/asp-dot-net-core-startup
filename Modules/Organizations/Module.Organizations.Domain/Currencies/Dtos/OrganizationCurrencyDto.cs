using Module.Organizations.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Organizations.Domain
{
    public class OrganizationCurrencyDto
    {
        public Guid Id { get; set; }
        public GuidIdNameDto Organization { get; set; }
        public CurrencyDto Currency { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<OrganizationCurrency, OrganizationCurrencyDto>> Selector()
        {
            return x => new OrganizationCurrencyDto
            {
                Id = x.Id,
                Currency = new CurrencyDto
                {
                    Id = x.CurrencyId,
                    Code = x.Currency.Code3,
                    Name = x.Currency.Name,
                    Symbol = x.Currency.Symbol
                },
                Organization = new GuidIdNameDto
                {
                    Id = x.OrganizationId,
                    Name = x.Organization.Name,
                },
                CreatedAt = x.CreatedAt
            };
        }
    }
}
