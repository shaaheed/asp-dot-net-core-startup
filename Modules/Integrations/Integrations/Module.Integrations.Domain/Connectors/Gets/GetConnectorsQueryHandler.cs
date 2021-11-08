using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Integrations.Domain
{
    public class GetConnectorsQueryHandler : IQueryHandler<GetConnectorsQuery, PagedCollection<ConnectorListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetConnectorsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<ConnectorListItemDto>> Handle(GetConnectorsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(ConnectorListItemDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
