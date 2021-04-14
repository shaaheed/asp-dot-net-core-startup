using Msi.Data.Entity;
using System;

namespace Module.Systems.Entities
{
    [IgnoredEntity]
    public class OrganizationCodeNameEntity : NameEntity, IHaveOrganizationEntity
    {
        public string Code { get; set; }
        public Guid? OrganizationId { get; set; }
    }
}
