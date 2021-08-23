using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Users.Domain
{
    public class GetRolesQueryHandler : IQueryHandler<GetRolesQuery, PagedCollection<RoleDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetRolesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(RoleDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
