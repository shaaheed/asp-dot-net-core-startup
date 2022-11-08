using Module.Accounts.Entities;
using Msi.Core;
using Msi.Data.Abstractions;
using Msi.Mediator.Abstractions;
using Msi.UtilityKit.Security;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Accounts.Domain
{
    public class ResetPasswordCommandHandler : ICommandHandler<ResetPasswordCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserForgotPasswordToken> _forgotPasswordTokenRepository;

        public ResetPasswordCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
            _forgotPasswordTokenRepository = _unitOfWork.GetRepository<UserForgotPasswordToken>();
        }

        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var token = await _forgotPasswordTokenRepository.FirstOrDefaultAsync(x => x.Token == request.ForgotPasswordToken);

            if (token == null)
                throw new ValidationException("Invalid token");

            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == token.UserId);

            var hashedPassword = request.Password.HashPassword();
            user.PasswordHash = hashedPassword;
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                var tokens = _forgotPasswordTokenRepository.Where(x => x.UserId == token.UserId).ToList();

                _forgotPasswordTokenRepository.RemoveRange(tokens);
                result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            return result > 0;
        }
    }
}
