using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Constructions.Domain
{
    public class GetProjectsQueryHandler : IQueryHandler<GetProjectsQuery, PagedCollection<ProjectListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetProjectsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<ProjectListItemDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(ProjectListItemDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
