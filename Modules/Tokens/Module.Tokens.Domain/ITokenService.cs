using Msi.Data.Entity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Module.Tokens.Domain
{
    public interface ITokenService
    {
        string GenerateRefreshToken();
        Task<TokenViewModel> CreateTokenViewModelAsync(Guid userId, string accessToken, string refreshToken);
        string GenerateToken(IEnumerable<Claim> claims);

        Task<IUser<Guid>> GetUser(string email, string hashedPassword);

        Task<IUser<Guid>> GetUser(Guid userId);
    }
}
