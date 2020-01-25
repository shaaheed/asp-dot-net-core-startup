using Core.Interfaces.Entities;

namespace Module.Users.Entities
{
    public class UserGroupResourceGroup : BaseEntity
    {
        public long ResourceGroupId { get; set; }
        public ResourceGroup ResourceGroup { get; set; }

        public long UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }

    }
}
