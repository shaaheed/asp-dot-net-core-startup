using Core.Interfaces.Entities;

namespace Module.Users.Entities
{
    public class UserGroupResourceOperation : BaseEntity
    {
        public long UserGroupResourceId { get; set; }
        public UserGroupResource UserGroupResource { get; set; }

        public long OperationId { get; set; }
        public Operation Operation { get; set; }

    }
}
