using Core.Infrastructure.Queries;
using System.Collections.Generic;

namespace Module.Organizations.Domain
{
    public class GetOrganizationsQuery : IQuery<IEnumerable<OrganizationDto>>
    {
    }
}
