using Msi.Mediator.Abstractions;
using System;

namespace Module.Users.Domain
{
    public class DeleteRoleCommand : ICommand<long>
    {
        public Guid Id { get; set; }

    }

}
