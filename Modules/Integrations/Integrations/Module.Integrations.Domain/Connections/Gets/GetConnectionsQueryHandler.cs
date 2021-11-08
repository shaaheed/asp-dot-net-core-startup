using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Integrations.Domain
{
    public class GetConnectionsQueryHandler : IQueryHandler<GetConnectionsQuery, PagedCollection<ConnectionListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetConnectionsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<ConnectionListItemDto>> Handle(GetConnectionsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(ConnectionListItemDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
