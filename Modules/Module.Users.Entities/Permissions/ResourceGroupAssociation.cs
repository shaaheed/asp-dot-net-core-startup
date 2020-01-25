using Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Module.Users.Entities
{
    public class ResourceGroupAssociation : BaseEntity
    {

        public ResourceGroupAssociation()
        {
            ResourceGroupAssociationOperations = new HashSet<ResourceGroupAssociationOperation>();
        }

        public long ResourceId { get; set; }
        public Resource Resource { get; set; }

        public long ResourceGroupId { get; set; }
        public ResourceGroup ResourceGroup { get; set; }

        public ICollection<ResourceGroupAssociationOperation> ResourceGroupAssociationOperations { get; protected set; }
    }
}
