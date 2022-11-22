using Msi.Mediator.Abstractions;
using System;

namespace Module.Permissions.Domain
{
    public class GetPermissionQuery : IQuery<PermissionDto>
    {
        public Guid Id { get; set; }
    }
}
