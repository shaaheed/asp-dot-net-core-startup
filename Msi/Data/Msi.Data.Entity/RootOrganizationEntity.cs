using System;

namespace Msi.Data.Entity
{
    [IgnoredEntity]
    public class RootOrganizationEntity : RootEntity, IOrganizationEntity
    {
        public Guid? OrganizationId { get; set; }
    }
}
