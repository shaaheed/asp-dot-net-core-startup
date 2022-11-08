using Msi.Mediator.Abstractions;

namespace Module.Accounts.Domain
{
    public class ForgotPasswordCommand : ICommand<bool>
    {
        public string Email { get; set; }
        public string ReturnUrl { get; set; }
    }
}
