using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Taxes
{
    public class GetTaxesQueryHandler : IQueryHandler<GetTaxesQuery, PagedCollection<TaxListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetTaxesQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<TaxListItemDto>> Handle(GetTaxesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(TaxListItemDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
