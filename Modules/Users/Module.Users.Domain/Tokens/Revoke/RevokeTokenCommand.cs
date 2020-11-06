using Msi.Mediator.Abstractions;

namespace Module.Users.Domain
{
    public class RevokeTokenCommand : ICommand<bool>
    {
        public string RefreshToken { get; set; }
    }
}
