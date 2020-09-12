using Module.Users.Entities;
using System.Threading;
using System.Threading.Tasks;
using Core.Infrastructure.Exceptions;
using Msi.Data.Abstractions;
using Msi.Mediator.Abstractions;

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
            var userRole = await _unitOfWork.GetRepository<Role>()
                .FirstOrDefaultAsync(x => x.Code == request.Role);

            if (userRole == null)
                throw new ValidationException($"Invalid role {request.Role}");

            var userRepo = _unitOfWork.GetRepository<User>();

            var xx = EntityBase.All<User>();
            User newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                //Email = request.Email,
                Mobile = request.Mobile,
                Contact = request.Contact
            };

            var cutomerCreatedEvent = new UserCreatedEvent();
            newUser.Append(cutomerCreatedEvent);
            var result = await newUser.SaveAsync(cancellationToken);

            var newUserRole = new UserRole
            {
                //UserId = newUser.Id,
                RoleId = userRole.Id
            };
            result += await newUserRole.SaveAsync(cancellationToken);
            return result;
        }
    }
}
