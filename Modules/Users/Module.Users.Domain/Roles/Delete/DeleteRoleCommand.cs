using Msi.Mediator.Abstractions;
using System;

namespace Module.Accounts.Domain
{
    public class DeleteRoleCommand : ICommand<long>
    {
        public Guid Id { get; set; }

    }

}
