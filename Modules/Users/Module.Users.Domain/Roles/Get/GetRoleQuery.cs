using Msi.Mediator.Abstractions;
using System;

namespace Module.Users.Domain
{
    public class GetRoleQuery : IQuery<RoleDto>
    {
        public Guid Id { get; set; }
    }
}
