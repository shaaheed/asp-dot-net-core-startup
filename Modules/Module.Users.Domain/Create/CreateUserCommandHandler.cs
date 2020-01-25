using Module.Users.Entities;
using Core.Infrastructure.Commands;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Users.Domain
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, long>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<User> _userRepository;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(newUser);

            if (request.UserGroupIds != null && request.UserGroupIds.Length > 0)
            {
                var userGroupAssociations = _unitOfWork.GetRepository<UserGroup>()
                    .Where(x => request.UserGroupIds.Contains(x.Id))
                    .Select(x => new UserGroupAssociation { UserId = newUser.Id, UserGroupId = x.Id })
                    .ToList();

                if (userGroupAssociations.Count() > 0)
                {
                    await _unitOfWork.GetRepository<UserGroupAssociation>().AddRangeAsync(userGroupAssociations);
                }
            }

            var result = await _unitOfWork.SaveChangesAsync();

            if (result <= 0)
            {
                //return await Response.Created(newUser.Id);
            }

            return -1;
        }
    }
}
