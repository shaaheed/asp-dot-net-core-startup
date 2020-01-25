using Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Module.Users.Entities
{
    public class UserGroupResource : BaseEntity
    {

        public UserGroupResource()
        {
            UserGroupResourceOperations = new HashSet<UserGroupResourceOperation>();
        }

        public long ResourceId { get; set; }
        public Resource Resource { get; set; }

        public long UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }

        public ICollection<UserGroupResourceOperation> UserGroupResourceOperations { get; private set; }

    }
}
