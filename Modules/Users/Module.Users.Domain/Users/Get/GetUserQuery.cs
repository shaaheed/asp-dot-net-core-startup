using Msi.Mediator.Abstractions;
using System;

namespace Module.Accounts.Domain
{
    public class GetUserQuery : IQuery<UserDto>
    {
        public Guid Id { get; set; }
    }
}
