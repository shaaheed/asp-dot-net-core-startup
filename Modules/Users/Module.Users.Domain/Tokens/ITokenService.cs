using Module.Users.Entities;
using Msi.Service;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Module.Users.Domain
{
    public interface ITokenService : IScopedService
    {
        string GenerateRefreshToken();
        Task<TokenViewModel> CreateTokenViewModelAsync(User user, string accessToken, string refreshToken);
        string GenerateToken(IEnumerable<Claim> claims);
    }
}
