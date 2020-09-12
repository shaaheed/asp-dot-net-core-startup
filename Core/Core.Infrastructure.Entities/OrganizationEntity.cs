using Core.Infrastructure.Attributes;
using Core.Interfaces.Entities;

namespace Core.Infrastructure.Entities
{
    [IgnoredEntity]
    public class OrganizationEntity : BaseEntity, IHaveOrganization
    {
    }
}
