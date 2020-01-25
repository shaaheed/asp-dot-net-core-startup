using Core.Interfaces.Entities;

namespace Module.Users.Entities
{
    public class UserResourceOperation : BaseEntity
    {
        public long UserResourceId { get; set; }
        public UserResource UserResource { get; set; }

        public long OperationId { get; set; }
        public Operation Operation { get; set; }

    }
}
