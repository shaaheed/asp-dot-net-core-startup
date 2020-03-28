using Core.Infrastructure.Permissions;
using Core.Interfaces.Entities;

namespace Module.Permissions.Entities
{
    public class Permission : BaseEntityWithTypeId<string>, IPermission
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
    }
}
