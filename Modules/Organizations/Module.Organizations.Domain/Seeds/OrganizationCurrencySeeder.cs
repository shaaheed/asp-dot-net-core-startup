using Module.Organizations.Entities;
using Msi.Data.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Organizations.Domain
{
    public class OrganizationCurrencySeeder : AbstractSeeder<OrganizationCurrency>
    {
        public override int Order => 1;
        public override IEnumerable<OrganizationCurrency> GetSeeds()
        {
            return new List<OrganizationCurrency>
            {
                new OrganizationCurrency
                {
                    Id = new Guid("d055308a-f2f7-43fa-a6dc-20b9e641adad"),
                    OrganizationId = new Guid("23ad3a5c-3a9e-4837-8501-908dd9017b73"),
                    // BDT
                    CurrencyId = new Guid("6f902863-ba4f-44a5-8b94-c9d7080b8b7c"),
                    ExchangeRate = 1, // As BDT default currency
                },
                new OrganizationCurrency
                {
                    Id = new Guid("c5efb5ab-d9cb-441f-a9ef-8aa1ad58a1f2"),
                    OrganizationId = new Guid("23ad3a5c-3a9e-4837-8501-908dd9017b73"),
                    // USD
                    CurrencyId = new Guid("7ce57a4f-bf49-4c07-8b5a-801f1431fa22"),
                    ExchangeRate = 100
                }
            };
        }
    }
}
