using Module.Users.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Mediator.Abstractions;

namespace Module.Users.Domain
{
    public class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, long>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<Role> _roleRepository;

        public CreateRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = _unitOfWork.GetRepository<Role>();
        }

        public async Task<long> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            Role newRole = new Role
            {
                Name = request.Name,
                Description = request.Description
            };
            var @event = new RoleCreatedEvent();
            //newUser.Append(cutomerCreatedEvent);
            await _roleRepository.AddAsync(newRole, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
