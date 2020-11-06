using Msi.Data.Abstractions;
using Msi.Data.Entity;

namespace Core.Infrastructure.Entities
{
    [IgnoredEntity]
    public class OrganizationEntity : BaseEntity, IHaveOrganization
    {
        public long? OrganizationId { get; set; }
    }
}
