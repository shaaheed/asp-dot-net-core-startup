using Module.Accounts.Entities;
using Msi.Core;
using Msi.Data.Abstractions;
using Msi.Mediator.Abstractions;
using Msi.UtilityKit.Security;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Accounts.Domain
{
    public class ForgotPasswordCommandHandler : ICommandHandler<ForgotPasswordCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserForgotPasswordToken> _forgotPasswordTokenRepository;

        public ForgotPasswordCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
            _forgotPasswordTokenRepository = _unitOfWork.GetRepository<UserForgotPasswordToken>();
        }

        public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Email.ToLower() == request.Email.ToLower());

            if (user == null)
                throw new ValidationException("Invalid email");

            var tokenString = (new Guid().ToString() + DateTime.Now.Ticks.ToString()).Encrypt();
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            tokenString = rgx.Replace(tokenString, "");

            var token = new UserForgotPasswordToken
            {
                UserId = user.Id,
                Token = tokenString
            };
            await _forgotPasswordTokenRepository.AddAsync(token);
            var result = await _unitOfWork.SaveChangesAsync();

            // sent email
            if (!string.IsNullOrEmpty(request.ReturnUrl) && result > 0)
            {
                var link = $"{request.ReturnUrl}?token={tokenString}";
                /*var htmlContent = await _viewRenderer.RenderViewToStringAsync("/Views/reset-password.cshtml", new ResetPasswordEmailModel { Link = link });
                _ = _emailSender.SendAsync(request.Email, "Reset Password", htmlContent);*/
            }
            return result > 0;
        }
    }
}
