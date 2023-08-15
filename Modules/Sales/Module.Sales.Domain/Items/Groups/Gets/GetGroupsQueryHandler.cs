using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Items
{
    public class GetGroupsQueryHandler : IQueryHandler<GetGroupsQuery, PagedCollection<GroupListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetGroupsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<GroupListItemDto>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(GroupListItemDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
