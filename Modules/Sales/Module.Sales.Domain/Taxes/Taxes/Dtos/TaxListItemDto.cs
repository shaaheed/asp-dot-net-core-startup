using Module.Sales.Entities;
using Module.Core.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Taxes
{
    public class TaxListItemDto : GuidCodeNameDto
    {
        public float Rate { get; set; }
        public bool IsCompoundTax { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Tax, TaxListItemDto>> Selector()
        {
            return x => new TaxListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Rate = x.Rate,
                IsCompoundTax = x.IsCompoundTax,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
