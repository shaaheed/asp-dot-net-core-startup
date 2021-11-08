using Msi.Data.Entity;
using System;

namespace Module.Integrations.Entities
{
    public class Provider : OrganizationEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
