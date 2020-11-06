using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Module.Users.Entities;
using Msi.Core;
using Msi.Data.Abstractions;
using Msi.Mediator.Abstractions;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Users.Domain
{
    public class RefreshTokenCommandHandler : ICommandHandler<RefreshTokenCommand, TokenViewModel>
    {
        private readonly JwtTokenOptions _jwtTokenOptions;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserToken> _userTokenRepository;
        private readonly IRepository<RefreshToken> _refreshTokenRepository;

        public RefreshTokenCommandHandler(
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

        public async Task<TokenViewModel> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            // Retrieve tokens
            var userToken = await _userTokenRepository
                .FirstOrDefaultAsync(x => x.AccessToken == request.AccessToken && x.RefreshToken.Token == request.RefreshToken);

            if (userToken == null)
                throw new ValidationException("Invalid token");

            // TODO: Check token expire time

            var principal = GetPrincipalFromExpiredToken(request.AccessToken);
            var username = principal.Identity.Name;

            var newJwtToken = _tokenService.GenerateToken(principal.Claims);
            var refreshToken = await _refreshTokenRepository.FirstOrDefaultAsync(x => x.Id == userToken.RefreshTokenId);

            // Delete old tokens
            _userTokenRepository.Remove(userToken);
            _refreshTokenRepository.Remove(refreshToken);

            // Save new tokens
            var newRefreshToken = new RefreshToken
            {
                Token = _tokenService.GenerateRefreshToken(),
                ExpiresIn = _jwtTokenOptions.RefreshTokenExpiration
            };
            await _refreshTokenRepository.AddAsync(newRefreshToken);
            var result = await _unitOfWork.SaveChangesAsync();

            var newUserToken = new UserToken
            {
                AccessToken = newJwtToken,
                RefreshTokenId = newRefreshToken.Id,
                ExpiresIn = _jwtTokenOptions.AccessTokenExpiration,
                UserId = userToken.UserId
            };
            await _userTokenRepository.AddAsync(newUserToken);

            result += await _unitOfWork.SaveChangesAsync();

            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == userToken.UserId);
            var tokenModel = await _tokenService.CreateTokenViewModelAsync(user, newJwtToken, newRefreshToken.Token);

            return tokenModel;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidIssuer = _jwtTokenOptions.Issuer,
                ValidateIssuer = true,
                ValidAudience = _jwtTokenOptions.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenOptions.SecretKey)),
                // We don't care about the token's expiration date
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
    }
}
