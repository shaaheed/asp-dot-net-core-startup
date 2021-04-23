using Module.Tokens.Entities;
using Msi.Core;
using Msi.Data.Abstractions;
using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Tokens.Domain
{
    public class RevokeTokenCommandHandler : ICommandHandler<RevokeTokenCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Token> _tokenRepository;
        private readonly IRepository<RefreshToken> _refreshTokenRepository;

        public RevokeTokenCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tokenRepository = _unitOfWork.GetRepository<Token>();
            _refreshTokenRepository = _unitOfWork.GetRepository<RefreshToken>();
        }

        public async Task<bool> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            var userToken = await _tokenRepository.FirstOrDefaultAsync(x => x.RefreshToken.Token == request.RefreshToken, cancellationToken);

            if (userToken == null)
                throw new NotFoundException("Invalid token");

            _tokenRepository.Remove(userToken);
            _refreshTokenRepository.Remove(userToken.RefreshToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
