using Module.Accounts.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Mediator.Abstractions;

namespace Module.Accounts.Domain
{
    public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand, long>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<Role> _roleRepository;

        public DeleteRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = _unitOfWork.GetRepository<Role>();
        }

        public async Task<long> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var user = new Role { Id = request.Id };
            _roleRepository.Remove(user);
            var response = await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(response);
        }
    }
}
