using Msi.Data.Entity;
using System;

namespace Module.Permissions.Entities
{
    // [Table(nameof(PermissionGroup), Schema = SchemaConstants.Core)]
    public class PermissionGroup : NameEntity
    {
        public PermissionGroup() : base()
        {

        }

        public PermissionGroup(Guid id, string name) : base(id, name)
        {
        }
    }
}
