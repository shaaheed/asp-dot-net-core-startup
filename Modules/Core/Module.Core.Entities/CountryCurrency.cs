using Msi.Data.Entity;
using System;

namespace Module.Core.Entities
{
    public class CountryCurrency : BaseEntity
    {
        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public bool IsDefault { get; set; }
        public bool IsFavourite { get; set; }
    }
}
