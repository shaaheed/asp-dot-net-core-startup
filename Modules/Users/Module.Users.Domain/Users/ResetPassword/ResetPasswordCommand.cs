using Msi.Mediator.Abstractions;

namespace Module.Users.Domain
{
    public class ResetPasswordCommand : ICommand<bool>
    {
        public string ForgotPasswordToken { get; set; }
        public string Password { get; set; }
    }
}
