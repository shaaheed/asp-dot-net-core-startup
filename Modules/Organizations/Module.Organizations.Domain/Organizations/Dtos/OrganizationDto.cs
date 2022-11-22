using Module.Organizations.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Organizations.Domain
{
    public class OrganizationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public bool IsDefault { get; set; }
        public CurrencyDto Currency { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Organization, OrganizationDto>> Selector()
        {
            return x => new OrganizationDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Owner = x.Owner,
                IsDefault = x.IsDefault,
                Mobile = x.AddressId != null ? x.Address.Phone : null,
                Address = x.AddressId != null ? x.Address.AddressLine1 : null,
                Currency = x.CurrencyId != null ? new CurrencyDto
                {
                    Id = (Guid)x.CurrencyId,
                    Code = x.Currency.Code3,
                    Name = x.Currency.Name,
                    Symbol = x.Currency.Symbol
                } : null,
                CreatedAt = x.CreatedAt
            };
        }

        public Expression<Func<Organization, OrganizationDto>> Selector2()
        {
            return Selector();
        }
    }
}
