using Core.Interfaces.Entities;

namespace Module.Organizations.Entities
{
    public class Organization : BaseEntity
    {        
        public string Name { get; set; }
        public OrganizationType Type { get; set; }
    }
}
