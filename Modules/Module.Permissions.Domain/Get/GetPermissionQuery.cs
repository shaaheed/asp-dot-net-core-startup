using Core.Infrastructure.Queries;

namespace Module.Permissions.Domain
{
    public class GetPermissionQuery : IQuery<PermissionDto>
    {
        public string Id { get; set; }
    }
}
