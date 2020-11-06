using Module.Users.Entities;
using Msi.Core;
using Msi.Data.Abstractions;
using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Users.Domain
{
    public class RevokeTokenCommandHandler : ICommandHandler<RevokeTokenCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserToken> _userTokenRepository;
        private readonly IRepository<RefreshToken> _refreshTokenRepository;

        public RevokeTokenCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userTokenRepository = _unitOfWork.GetRepository<UserToken>();
            _refreshTokenRepository = _unitOfWork.GetRepository<RefreshToken>();
        }

        public async Task<bool> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            var userToken = await _userTokenRepository.FirstOrDefaultAsync(x => x.RefreshToken.Token == request.RefreshToken, false, cancellationToken);

            if (userToken == null)
                throw new NotFoundException("Invalid token");

            _userTokenRepository.Remove(userToken);
            _refreshTokenRepository.Remove(userToken.RefreshToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
