using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Units
{
    public class GetVariantOptionsQueryHandler : IQueryHandler<GetVariantOptionsQuery, PagedCollection<VariantOptionDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetVariantOptionsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<VariantOptionDto>> Handle(GetVariantOptionsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(x => x.VariantId == request.VariantId, VariantOptionDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
