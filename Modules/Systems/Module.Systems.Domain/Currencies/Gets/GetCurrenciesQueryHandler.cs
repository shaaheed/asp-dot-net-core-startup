using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Systems.Domain
{
    public class GetCurrenciesQueryHandler : IQueryHandler<GetCurrenciesQuery, PagedCollection<CurrencyDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetCurrenciesQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<CurrencyDto>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(CurrencyDto.Selector(), request.PagingOptions, request.SearchOptions, cancellationToken);
        }
    }
}
