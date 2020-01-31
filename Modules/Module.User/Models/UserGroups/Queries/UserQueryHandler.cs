using Module.Users.Entities;
using Core.Infrastructure.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;
using System.Linq;

namespace Application.UserGroups.Queries
{
    public class UserGroupQueryHandler : IQueryHandler<GetUserGroupsQuery, ICollection<UserGroup>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserGroup> _userGroupRepository;

        public UserGroupQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userGroupRepository = _unitOfWork.GetRepository<UserGroup>();
        }

        public async Task<ICollection<UserGroup>> Handle(GetUserGroupsQuery request, CancellationToken cancellationToken)
        {
            var result = _userGroupRepository.AsQueryable().ToList();
            return await Task.FromResult(result);
        }
    }
}
