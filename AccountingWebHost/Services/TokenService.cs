using Microsoft.Extensions.Options;
using Module.Tokens.Domain;
using Module.Users.Entities;
using Msi.Data.Abstractions;
using Msi.Data.Entity;
using Msi.Service.Abstractions;
using System;
using System.Threading.Tasks;

namespace Services
{
    public class TokenService : AbstractTokenService, IScopedService
    {
        private readonly IRepository<User> _userRepository;

        public TokenService(
            IUnitOfWork unitOfWork,
            IOptions<JwtTokenOptions> jwtTokenOptions) : base(jwtTokenOptions)
        {
            _userRepository = unitOfWork.GetRepository<User>();
        }

        public override async Task<IUser<Guid>> GetUser(string email, string hashedPassword)
        {
            return await _userRepository.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower() && x.PasswordHash == hashedPassword);
        }

        public override async Task<IUser<Guid>> GetUser(Guid userId)
        {
            return await _userRepository.FirstOrDefaultAsyncAsReadOnly(x => x.Id == userId);
        }
    }
}
