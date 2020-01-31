using Module.Users.Entities;
using Core.Infrastructure.Commands;
using Core.Infrastructure.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Application.UserGroups.Commands
{
    public class CreateUserGroupCommandHandler : ICommandHandler<CreateUserGroupCommand, CommandResponse<long>>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<UserGroup> _userGroupRepository;

        public CreateUserGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userGroupRepository = _unitOfWork.GetRepository<UserGroup>();
        }

        public async Task<CommandResponse<long>> Handle(CreateUserGroupCommand request, CancellationToken cancellationToken)
        {

            var newUserGroup = new UserGroup
            {
                Name = request.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _userGroupRepository.AddAsync(newUserGroup);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result <= 0)
            {
                //return await Response.Created(newUserGroup.Id);
            }

            return null;
        }
    }
}
