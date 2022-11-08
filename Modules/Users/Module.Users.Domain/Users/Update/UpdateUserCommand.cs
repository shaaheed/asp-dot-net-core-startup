using Msi.Mediator.Abstractions;
using System;

namespace Module.Accounts.Domain
{
    public class UpdateUserCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Contact { get; set; }

    }

}
