using Module.Accounts.Entities;
using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Accounts.Domain
{
    public class GetRoleQueryHandler : IQueryHandler<GetRoleQuery, RoleDto>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Role> _roleRepository;

        public GetRoleQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = _unitOfWork.GetRepository<Role>();
        }

        public Task<RoleDto> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            return _roleRepository.GetAsync(x => x.Id == request.Id, RoleDto.Selector(), cancellationToken);
        }
    }
}
