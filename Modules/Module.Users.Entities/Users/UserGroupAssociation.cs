using Core.Interfaces.Entities;

namespace Module.Users.Entities
{
    public class UserGroupAssociation : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public long UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }

    }
}
