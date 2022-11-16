using Msi.Data.Entity;
using System;

namespace Module.Permissions.Entities
{
    // [Table(nameof(PermissionGroup), Schema = SchemaConstants.Core)]
    public class PermissionGroup : BaseEntity<long>, INameEntity
    {
        public string Name { get; set; }
    }
}
