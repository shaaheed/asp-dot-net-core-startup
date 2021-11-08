using Msi.Mediator.Abstractions;
using System.Threading;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;
using System.Threading.Tasks;

namespace Module.Integrations.Domain
{
    public class GetProvidersQueryHandler : IQueryHandler<GetProvidersQuery, PagedCollection<ProviderListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetProvidersQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<ProviderListItemDto>> Handle(GetProvidersQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(ProviderListItemDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
