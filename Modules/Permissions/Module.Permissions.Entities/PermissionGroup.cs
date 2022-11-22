using Msi.Data.Entity;
using System;

namespace Module.Permissions.Entities
{
    // [Table(nameof(PermissionGroup), Schema = SchemaConstants.Core)]
    public class PermissionGroup : NameEntity
    {

        public PermissionGroup()
        {

        }

        public PermissionGroup(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
