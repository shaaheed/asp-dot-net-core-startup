using Core.Infrastructure.Queries;

namespace Module.Organizations.Domain
{
    public class GetOrganizationQuery : IQuery<OrganizationDto>
    {
        public long Id { get; set; }
    }
}
