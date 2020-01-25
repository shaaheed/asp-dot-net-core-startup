using Core.Interfaces.Entities;

namespace Module.Core.Entities
{
    public class CountryCurrency : BaseEntity
    {
        public long CountryId { get; set; }
        public Country Country { get; set; }

        public long CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public bool IsDefault { get; set; }
        public bool IsFavourite { get; set; }
    }
}
