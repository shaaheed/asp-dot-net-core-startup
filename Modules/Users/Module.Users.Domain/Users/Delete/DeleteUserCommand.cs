using Msi.Mediator.Abstractions;
using System;

namespace Module.Users.Domain
{
    public class DeleteUserCommand : ICommand<long>
    {
        public Guid Id { get; set; }

    }

}
