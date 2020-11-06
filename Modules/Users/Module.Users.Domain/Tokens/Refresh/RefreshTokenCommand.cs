using Msi.Mediator.Abstractions;

namespace Module.Users.Domain
{
    public class RefreshTokenCommand : ICommand<TokenViewModel>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
