using Module.Users.Entities;
using Core.Infrastructure.Commands;
using Core.Infrastructure.Responses;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Application.UserGroups.Commands
{
    public class UpdateUserGroupCommandHandler : ICommandHandler<UpdateUserGroupCommand, CommandResponse<long>>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<UserGroup> _userGroupRepository;

        public UpdateUserGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userGroupRepository = _unitOfWork.GetRepository<UserGroup>();
        }

        public async Task<CommandResponse<long>> Handle(UpdateUserGroupCommand request, CancellationToken cancellationToken)
        {

            var userGroup = await _userGroupRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

            userGroup.Name = request.Name;

            var result = await _unitOfWork.SaveChangesAsync();

            if (result <= 0)
            {
                //return await Response.Updated(userGroup.Id);
            }

            return null;
        }
    }
}
