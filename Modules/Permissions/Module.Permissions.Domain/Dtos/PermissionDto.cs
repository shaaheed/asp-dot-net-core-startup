using System;

namespace Module.Permissions.Domain
{
    public class PermissionDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
    }
}
