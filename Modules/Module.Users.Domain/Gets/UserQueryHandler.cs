using Module.Users.Entities;
using Core.Infrastructure.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Users.Domain
{
    public class UserQueryHandler : IQueryHandler<GetUsersQuery, object>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;

        public UserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<object> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = _userRepository
                .AsQueryable()
                .Select(x => new
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Groups = x.UserGroupAssociations.Select(y => new { Id = y.UserGroupId, Name = y.UserGroup.Name }).ToList()
                })
                .ToList();
            return result;
        }
    }
}
