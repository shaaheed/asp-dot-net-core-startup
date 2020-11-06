using Module.Users.Entities;
using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Users.Domain
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, long>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<User> _userRepository;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<long> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user != null)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;

                var result = await _unitOfWork.SaveChangesAsync();
                return result;
            }

            return 0;
        }
    }
}
