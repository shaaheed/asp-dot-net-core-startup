using Msi.Data.Entity;
using System;

namespace Module.Systems.Entities
{
    [IgnoredEntity]
    public class OrganizationNameEntity : NameEntity, IOrganizationEntity
    {
        public Guid? OrganizationId { get; set; }
    }
}
