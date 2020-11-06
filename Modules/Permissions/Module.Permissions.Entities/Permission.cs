using Msi.Data.Entity;

namespace Module.Permissions.Entities
{
    public class Permission : BaseEntity<long>
    {
        public Permission()
        {

        }

        public Permission(long id, string name, string code, long groupId)
        {
            Id = id;
            Name = name;
            Code = code;
            GroupId = groupId;
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public long GroupId { get; set; }
        public PermissionGroup Group { get; set; }
    }
}
