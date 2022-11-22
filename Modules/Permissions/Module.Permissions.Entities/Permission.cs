using Msi.Data.Entity;
using System;

namespace Module.Permissions.Entities
{
    public class Permission : BaseEntity
    {
        public Permission()
        {

        }

        public Permission(Guid id, string name, string code, Guid groupId)
        {
            Id = id;
            Name = name;
            Code = code;
            GroupId = groupId;
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public Guid GroupId { get; set; }
        public virtual PermissionGroup Group { get; set; }
    }
}
