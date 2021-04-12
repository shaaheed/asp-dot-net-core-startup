using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Organizations.Domain
{
    public class GetOrganizationsQueryHandler : IQueryHandler<GetOrganizationsQuery, PagedCollection<OrganizationListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetOrganizationsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<OrganizationListItemDto>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(OrganizationListItemDto.Selector(), request.PagingOptions, request.SearchOptions, cancellationToken);
        }
    }
}
