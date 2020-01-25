using Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Module.Users.Entities
{
    public class UserResource : BaseEntity
    {

        public UserResource()
        {
            UserResourceOperations = new HashSet<UserResourceOperation>();
        }

        public long ResourceId { get; set; }
        public Resource Resource { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public ICollection<UserResourceOperation> UserResourceOperations { get; protected set; }

    }
}
