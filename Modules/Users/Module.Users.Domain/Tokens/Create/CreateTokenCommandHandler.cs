using Microsoft.Extensions.Options;
using Module.Users.Entities;
using Msi.Core;
using Msi.Data.Abstractions;
using Msi.Mediator.Abstractions;
using Msi.UtilityKit.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Users.Domain
{
    public class CreateTokenCommandHandler : ICommandHandler<CreateTokenCommand, TokenViewModel>
    {
        private readonly JwtTokenOptions _jwtTokenOptions;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserToken> _userTokenRepository;
        private readonly IRepository<RefreshToken> _refreshTokenRepository;
        private static long ToUnixEpochDate(DateTime date)
  => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        public CreateTokenCommandHandler(
            IUnitOfWork unitOfWork,
            ITokenService tokenService,
            IOptions<JwtTokenOptions> jwtTokenOptions)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _jwtTokenOptions = jwtTokenOptions.Value;
            _userRepository = _unitOfWork.GetRepository<User>();
            _userTokenRepository = _unitOfWork.GetRepository<UserToken>();
            _refreshTokenRepository = _unitOfWork.GetRepository<RefreshToken>();
        }

        public async Task<TokenViewModel> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            string hashedPassword = request.Password.HashPassword();
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Email.ToLower() == request.Email.ToLower() && x.PasswordHash == hashedPassword);

            if (user == null)
                throw new ValidationException("Invalid email or password");

            return await CreateAsync(user.Id);
        }

        private async Task<TokenViewModel> CreateAsync(Guid userId)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == userId, true);

            if (user == null)
                throw new NotFoundException("User not found");

            // Delete old tokens
            var oldTokens = _userTokenRepository.Where(x => x.UserId == userId);
            var oldRefreshTokens = oldTokens.Select(x => x.RefreshToken);

            _userTokenRepository.RemoveRange(oldTokens);
            _refreshTokenRepository.RemoveRange(oldRefreshTokens);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("user_id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtTokenOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtTokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64)
            };

            var refreshToken = new RefreshToken
            {
                Token = _tokenService.GenerateRefreshToken(),
                ExpiresIn = _jwtTokenOptions.RefreshTokenExpiration
            };

            await _refreshTokenRepository.AddAsync(refreshToken);
            await _unitOfWork.SaveChangesAsync();

            var userToken = new UserToken
            {
                AccessToken = _tokenService.GenerateToken(claims),
                RefreshTokenId = refreshToken.Id,
                ExpiresIn = _jwtTokenOptions.AccessTokenExpiration,
                UserId = userId
            };

            await _userTokenRepository.AddAsync(userToken);
            var result = await _unitOfWork.SaveChangesAsync();

            var tokenModel = await _tokenService.CreateTokenViewModelAsync(user, userToken.AccessToken, refreshToken.Token);

            return tokenModel;
        }
    }
}
