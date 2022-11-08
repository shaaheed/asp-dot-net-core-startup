using Msi.Mediator.Abstractions;
using System;

namespace Module.Accounts.Domain
{
    public class GetRoleQuery : IQuery<RoleDto>
    {
        public Guid Id { get; set; }
    }
}
