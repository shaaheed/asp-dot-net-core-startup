using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Constructions.Domain
{
    public class GetFootingsQueryHandler : IQueryHandler<GetFootingsQuery, PagedCollection<FootingDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetFootingsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<FootingDto>> Handle(GetFootingsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(FootingDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
