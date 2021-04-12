using Module.Systems.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Systems.Domain
{
    public class CurrencyDto : GuidCodeNameDto
    {
        public string Symbol { get; set; }

        public static Expression<Func<Currency, CurrencyDto>> Selector()
        {
            return x => new CurrencyDto
            {
                Id = x.Id,
                Code = x.Code3,
                Name = x.Name,
                Symbol = x.Symbol
            };
        }
    }
}
