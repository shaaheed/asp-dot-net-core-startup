using Core.Interfaces.Data;
using Module.Organizations.Entities;
using System.Collections.Generic;

namespace Module.Organizations.Data
{
    public class OrganizationSeeds : ISeed<Organization>
    {
        public int Order => 1;
        public IEnumerable<Organization> GetSeeds()
        {
            return new List<Organization>
            {
                new Organization(1) {
                    Name = "Default",
                    CurrencyId = 13
                }
            };
        }
    }
}
