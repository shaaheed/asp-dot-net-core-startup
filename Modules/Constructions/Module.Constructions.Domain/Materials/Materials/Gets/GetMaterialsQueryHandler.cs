using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Constructions.Domain
{
    public class GetMaterialsQueryHandler : IQueryHandler<GetMaterialsQuery, PagedCollection<MaterialDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetMaterialsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<MaterialDto>> Handle(GetMaterialsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(MaterialDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
