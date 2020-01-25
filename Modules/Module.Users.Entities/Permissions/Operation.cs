using Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Module.Users.Entities
{
    public class Operation : BaseEntity
    {

        public Operation()
        {
            ResourceOperations = new HashSet<ResourceOperation>();
            ResourceGroupAssociationOperations = new HashSet<ResourceGroupAssociationOperation>();
            UserGroupResourceOperations = new HashSet<UserGroupResourceOperation>();
            UserResourceOperations = new HashSet<UserResourceOperation>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<ResourceOperation> ResourceOperations { get; protected set; }
        public ICollection<ResourceGroupAssociationOperation> ResourceGroupAssociationOperations { get; protected set; }
        public ICollection<UserGroupResourceOperation> UserGroupResourceOperations { get; private set; }
        public ICollection<UserResourceOperation> UserResourceOperations { get; protected set; }
    }
}
