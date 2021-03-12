using Msi.Mediator.Abstractions;

namespace Module.Tokens.Domain
{
    public class RevokeTokenCommand : ICommand<bool>
    {
        public string RefreshToken { get; set; }
    }
}
