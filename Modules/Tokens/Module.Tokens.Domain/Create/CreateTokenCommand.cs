using Msi.Mediator.Abstractions;

namespace Module.Tokens.Domain
{
    public class CreateTokenCommand : ICommand<TokenViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
