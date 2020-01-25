using Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Module.Users.Entities
{
    public class ResourceGroup : BaseEntity
    {
        public ResourceGroup()
        {
            ResourceGroupAssociations = new HashSet<ResourceGroupAssociation>();
            UserGroupResourceGroups = new HashSet<UserGroupResourceGroup>();
            UserResourceGroups = new HashSet<UserResourceGroup>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ICollection<ResourceGroupAssociation> ResourceGroupAssociations { get; protected set; }
        public ICollection<UserGroupResourceGroup> UserGroupResourceGroups { get; protected set; }
        public ICollection<UserResourceGroup> UserResourceGroups { get; protected set; }
        
    }
}
