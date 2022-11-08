using Msi.Mediator.Abstractions;
using System;

namespace Module.Accounts.Domain
{
    public class DeleteUserCommand : ICommand<long>
    {
        public Guid Id { get; set; }

    }

}
