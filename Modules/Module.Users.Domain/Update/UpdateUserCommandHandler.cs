using Module.Users.Entities;
using Core.Infrastructure.Commands;
using Core.Infrastructure.Responses;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Users.Domain
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, CommandResponse<long>>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<User> _userRepository;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<CommandResponse<long>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user != null)
            {

                var validRequestUserGroupIds = _unitOfWork.GetRepository<UserGroup>()
                    .Where(x => request.UserGroupIds.Contains(x.Id))
                    .Select(x => x.Id)
                    .ToList();

                var userGroupAssociationRepo = _unitOfWork.GetRepository<UserGroupAssociation>();
                var dbUserGroupAssociations = userGroupAssociationRepo
                    .Where(x => x.UserId == request.Id)
                    .Select(x => new { Id = x.Id, UserGroupId = x.UserGroupId })
                    .ToList();

                // Delete UserGroupAssociations
                var userGroupAssociationsToBeRemoved = dbUserGroupAssociations
                    .Where(x => !validRequestUserGroupIds.Contains(x.UserGroupId))
                    .Select(x => new UserGroupAssociation { Id = x.Id });

                if (userGroupAssociationsToBeRemoved.Count() > 0)
                {
                    userGroupAssociationRepo.RemoveRange(userGroupAssociationsToBeRemoved);
                }

                // Create UserGroupAssociations
                var userGroupAssiciationsToBeAdded = validRequestUserGroupIds
                    .Where(x => !dbUserGroupAssociations.Select(y => y.UserGroupId).Contains(x))
                    .Select(x => new UserGroupAssociation
                    {
                        UserId = request.Id,
                        UserGroupId = x
                    });

                if (userGroupAssiciationsToBeAdded.Count() > 0)
                {
                    await userGroupAssociationRepo.AddRangeAsync(userGroupAssiciationsToBeAdded);
                }

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;

                var result = await _unitOfWork.SaveChangesAsync();

                if (result <= 0)
                {
                    //return await Response.Created(user.Id);
                }
            }

            return null;
        }
    }
}
