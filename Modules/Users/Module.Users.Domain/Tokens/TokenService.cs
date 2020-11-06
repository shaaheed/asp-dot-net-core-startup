using Microsoft.Extensions.Options;
using Module.Users.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Module.Users.Domain
{
    public class TokenService : ITokenService
    {
        private readonly JwtTokenOptions _jwtTokenOptions;
        //private readonly IAppService _appService;

        public TokenService(
            IOptions<JwtTokenOptions> jwtTokenOptions
            //IAppService appService,
            )
        {
            //_appService = appService;
            _jwtTokenOptions = jwtTokenOptions.Value;
        }

        public async Task<TokenViewModel> CreateTokenViewModelAsync(User user, string accessToken, string refreshToken)
        {
            /*var userRoles = _unitOfWork.GetRepository<UserRole>()
                .AsReadOnly()
                .Where(x => x.UserId == user.Id)
                .Select(x => new IdNameViewModel
                {
                    Id = x.RoleId,
                    Name = x.Role.Name
                })
                .ToList();

            var profilePhoto = await _unitOfWork.GetRepository<UserProfile>()
                .Where(x => x.UserId == user.Id && !x.IsDeleted)
                .Select(x => x.Media.FileName)
                .FirstOrDefaultAsync();

            if (!string.IsNullOrEmpty(profilePhoto))
            {
                profilePhoto = Path.Combine(_appService.GetServerUrl(), MediaConstants.Path, profilePhoto);
            }*/

            var token = new TokenViewModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = (int)_jwtTokenOptions.AccessTokenValidFor.TotalSeconds,
                UserId = user.Id,
                /*UserInfo = new UserInfoViewModel
                {
                    Id = user.Id,
                    Name = user.FullName,
                    Email = user.Email,
                    Roles = userRoles,
                    Photo = profilePhoto
                }*/
            };

            return await Task.FromResult(token);
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
                issuer: _jwtTokenOptions.Issuer,
                audience: _jwtTokenOptions.Audience,
                claims: claims,
                notBefore: _jwtTokenOptions.NotBefore,
                expires: _jwtTokenOptions.AccessTokenExpiration,
                signingCredentials: _jwtTokenOptions.SigningCredentials);
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string GenerateRefreshToken()
        {
            var bytes = new byte[32];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
