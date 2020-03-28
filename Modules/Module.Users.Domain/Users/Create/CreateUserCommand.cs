using Core.Infrastructure.Commands;

namespace Module.Users.Domain
{
    public class CreateUserCommand : ICommand<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Contact { get; set; }

        // hold role code
        public string Role { get; set; }

    }

}
