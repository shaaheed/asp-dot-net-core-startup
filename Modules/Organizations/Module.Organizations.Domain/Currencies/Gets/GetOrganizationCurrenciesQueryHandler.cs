using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Organizations.Domain
{
    public class GetOrganizationCurrenciesQueryHandler : IQueryHandler<GetOrganizationCurrenciesQuery, PagedCollection<OrganizationCurrencyDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetOrganizationCurrenciesQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<OrganizationCurrencyDto>> Handle(GetOrganizationCurrenciesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(x => x.OrganizationId == request.OrganizationId, OrganizationCurrencyDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
