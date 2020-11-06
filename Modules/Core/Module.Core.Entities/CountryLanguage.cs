using Msi.Data.Entity;
using System;

namespace Module.Core.Entities
{
    public class CountryLanguage : BaseEntity
    {
        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public Guid LanguageId { get; set; }
        public Language Language { get; set; }

        public bool IsDefault { get; set; }
        public bool IsFavourite { get; set; }
        public bool IsOfficial { get; set; }
    }
}
