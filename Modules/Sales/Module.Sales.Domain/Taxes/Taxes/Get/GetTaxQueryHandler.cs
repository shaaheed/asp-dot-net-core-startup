using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Taxes
{
    public class GetTaxQueryHandler : IQueryHandler<GetTaxQuery, TaxDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetTaxQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<TaxDto> Handle(GetTaxQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, TaxDto.Selector(), cancellationToken);
        }
    }
}
