using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class GetVariantOptionQueryHandler : IQueryHandler<GetVariantOptionQuery, VariantOptionDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetVariantOptionQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<VariantOptionDto> Handle(GetVariantOptionQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, VariantOptionDto.Selector(), cancellationToken);
        }
    }
}
