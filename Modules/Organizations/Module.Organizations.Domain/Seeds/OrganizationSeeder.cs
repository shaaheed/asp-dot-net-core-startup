using Module.Organizations.Entities;
using Msi.Data.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Organizations.Domain
{
    public class OrganizationSeeder : AbstractSeeder<Organization>
    {
        public override int Order => 1;
        public override IEnumerable<Organization> GetSeeds()
        {
            return new List<Organization>
            {
                new Organization() {
                    Id = new Guid("23ad3a5c-3a9e-4837-8501-908dd9017b73"),
                    Name = "Default",
                    // BDT
                    CurrencyId = new Guid("6f902863-ba4f-44a5-8b94-c9d7080b8b7c")
                }
            };
        }
    }
}
