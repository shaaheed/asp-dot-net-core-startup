using Core.Interfaces.Entities;

namespace Module.Users.Entities
{
    public class Permission : BaseEntity
    {

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }

        public long? ResourceId { get; set; }
        public Resource Resource { get; set; }

        public long? OperationId { get; set; }
        public Operation Operation { get; set; }

        public long? ResourceGroupId { get; set; }
        public ResourceGroupAssociation ResourceGroupAssociation { get; set; }


    }
}
