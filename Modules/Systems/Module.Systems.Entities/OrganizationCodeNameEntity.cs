using Msi.Data.Entity;

namespace Module.Systems.Entities
{
    [IgnoredEntity]
    public class OrganizationCodeNameEntity : NameEntity, IOrganizationEntity
    {
        public string Code { get; set; }
        public Guid? OrganizationId { get; set; }
    }
}
