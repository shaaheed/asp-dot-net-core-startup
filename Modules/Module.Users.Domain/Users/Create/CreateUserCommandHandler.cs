using Module.Users.Entities;
using Core.Infrastructure.Commands;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;
using Core.Infrastructure.Exceptions;

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
            User newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Mobile = request.Mobile,
                Contact = request.Contact
            };

            var cutomerCreatedEvent = new UserCreatedEvent();
            newUser.Append(cutomerCreatedEvent);
            await userRepo.AddAsync(newUser, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var newUserRole = new UserRole
            {
                UserId = newUser.Id,
                RoleId = userRole.Id
            };

            await _unitOfWork.GetRepository<UserRole>().AddAsync(newUserRole, cancellationToken);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
