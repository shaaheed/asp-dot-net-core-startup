using Module.Users.Entities;
using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Users.Domain
{
    public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand, long>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<Role> _roleRepository;

        public UpdateRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = _unitOfWork.GetRepository<Role>();
        }

        public async Task<long> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {

            var role = await _roleRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (role != null)
            {
                role.Name = request.Name;
                role.Description = request.Description;

                var result = await _unitOfWork.SaveChangesAsync();
                return result;
            }

            return 0;
        }
    }
}
