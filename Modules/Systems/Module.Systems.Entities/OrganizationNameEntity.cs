using Msi.Data.Entity;

namespace Module.Systems.Entities
{
    [IgnoredEntity]
    public class OrganizationNameEntity : NameEntity, IOrganizationEntity
    {
        public Guid? OrganizationId { get; set; }
    }
}
