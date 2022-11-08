using Module.Accounts.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Mediator.Abstractions;

namespace Module.Accounts.Domain
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, long>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<User> _userRepository;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<long> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { Id = request.Id };
            _userRepository.Remove(user);
            var response = await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(response);
        }
    }
}
