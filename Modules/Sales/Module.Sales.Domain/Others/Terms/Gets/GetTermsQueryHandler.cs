using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Units
{
    public class GetTermsQueryHandler : IQueryHandler<GetTermsQuery, PagedCollection<TermDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetTermsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedCollection<TermDto>> Handle(GetTermsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ListAsync(TermDto.Selector(), request.FilterOptions, cancellationToken);
            return result;
        }
    }
}
