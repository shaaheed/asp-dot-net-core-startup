using Msi.Mediator.Abstractions;

namespace Module.Permissions.Domain
{
    public class GetPermissionQuery : IQuery<PermissionDto>
    {
        public long Id { get; set; }
    }
}
