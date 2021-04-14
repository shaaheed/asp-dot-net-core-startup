using System;

namespace Msi.Data.Entity
{
    [IgnoredEntity]
    public class OrganizationBaseEntity : BaseEntity, IHaveOrganizationEntity
    {
        public Guid? OrganizationId { get; set; }
    }
}
