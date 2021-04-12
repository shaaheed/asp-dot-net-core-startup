using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Organizations.Domain
{
    public class GetOrganizationsQuery : Query<PagedCollection<OrganizationListItemDto>>
    {
    }
}
