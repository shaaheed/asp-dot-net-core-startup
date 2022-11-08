using Module.Organizations.Entities;
using Msi.Data.Entity;

namespace Module.Organizations.Domain
{
    public class OrganizationSeeds : ISeed<Organization>
    {
        public int Order => 1;
        public IEnumerable<Organization> GetSeeds()
        {
            return new List<Organization>
            {
                new Organization(Guid.Parse("23ad3a5c-3a9e-4837-8501-908dd9017b73")) {
                    Name = "Default"
                }
            };
        }
    }
}
