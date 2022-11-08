using Module.Accounts.Entities;
using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using System.Collections.Generic;
using Msi.Utilities.Filter;

namespace Module.Accounts.Domain
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, PagedCollection<UserDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var selector = DataExtensions.DynamicSelect<User>(new HashSet<string> { "Id", "FirstName", "Email", "Mobile" });
            return _unitOfWork.ListAsync(UserDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
