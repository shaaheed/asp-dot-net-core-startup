using Core.Interfaces.Entities;

namespace Module.Users.Entities
{
    public class UserResourceGroup : BaseEntity
    {
        public long ResourceGroupId { get; set; }
        public ResourceGroup ResourceGroup { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

    }
}
