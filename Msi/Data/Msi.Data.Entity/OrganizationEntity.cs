namespace Msi.Data.Entity
{
    [IgnoredEntity]
    public class OrganizationEntity : BaseEntity, IOrganizationEntity
    {
        public Guid? OrganizationId { get; set; }
    }
}
