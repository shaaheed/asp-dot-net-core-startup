using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class GetVariantQueryHandler : IQueryHandler<GetVariantQuery, VariantDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetVariantQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<VariantDto> Handle(GetVariantQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, VariantDto.Selector(), cancellationToken);
        }
    }
}
