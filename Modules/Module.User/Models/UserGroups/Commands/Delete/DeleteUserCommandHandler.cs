using Module.Users.Entities;
using Core.Infrastructure.Commands;
using Core.Infrastructure.Responses;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Application.UserGroups.Commands
{
    public class DeleteUserGroupCommandHandler : ICommandHandler<DeleteUserGroupCommand, CommandResponse<long>>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<User> _userRepository;

        public DeleteUserGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<CommandResponse<long>> Handle(DeleteUserGroupCommand request, CancellationToken cancellationToken)
        {
            var user = new User { Id = request.Id };
            _userRepository.Remove(user);
            var response = new CommandResponse<long>(await _unitOfWork.SaveChangesAsync(), 200, string.Empty);
            return await Task.FromResult(response);
        }
    }
}
