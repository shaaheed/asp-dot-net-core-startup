using Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Module.Users.Entities
{
    public class Resource : BaseEntity
    {

        public Resource()
        {
            ResourceGroupAssociations = new HashSet<ResourceGroupAssociation>();
            ResourceOperations = new HashSet<ResourceOperation>();
            UserGroupResources = new HashSet<UserGroupResource>();
            UserResources = new HashSet<UserResource>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ICollection<ResourceGroupAssociation> ResourceGroupAssociations { get; protected set; }
        public ICollection<ResourceOperation> ResourceOperations { get; protected set; }
        public ICollection<UserGroupResource> UserGroupResources { get; protected set; }
        public ICollection<UserResource> UserResources { get; protected set; }
        public Permission Permission { get; set; }
    }
}
