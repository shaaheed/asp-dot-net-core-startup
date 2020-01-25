using Core.Interfaces.Entities;

namespace Module.Core.Entities
{
    public class CountryLanguage : BaseEntity
    {
        public long CountryId { get; set; }
        public Country Country { get; set; }

        public long LanguageId { get; set; }
        public Language Language { get; set; }

        public bool IsDefault { get; set; }
        public bool IsFavourite { get; set; }
        public bool IsOfficial { get; set; }
    }
}
