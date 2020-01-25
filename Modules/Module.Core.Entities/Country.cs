using Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Module.Core.Entities
{
    public class Country : BaseEntity
    {
        public Country()
        {
            CountryLanguages = new HashSet<CountryLanguage>();
            CountryCurrencies = new HashSet<CountryCurrency>();
            StatesOrProvinces = new HashSet<StateOrProvince>();
        }

        public string Name { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        public string LongName { get; set; }
        public string NativeName { get; set; }
        public string Domain { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string Capital { get; set; }
        public string CallingCode { get; set; }
        public string NumericCode { get; set; }
        public string IDD { get; set; }
        public string NDD { get; set; }
        public string Flag { get; set; }
        public bool IsIndependent { get; set; }
        public bool IsBillingEnabled { get; set; }
        public bool IsShippingEnabled { get; set; }
        public bool IsCityEnabled { get; set; } = true;
        public bool IsZipCodeEnabled { get; set; } = true;
        public bool IsDistrictEnabled { get; set; } = true;

        public ICollection<StateOrProvince> StatesOrProvinces { get; set; }
        public virtual ICollection<CountryLanguage> CountryLanguages { get; set; }
        public virtual ICollection<CountryCurrency> CountryCurrencies { get; set; }

    }
}
