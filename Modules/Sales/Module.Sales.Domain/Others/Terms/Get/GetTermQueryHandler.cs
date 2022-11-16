using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Units
{
    public class GetTermQueryHandler : IQueryHandler<GetTermQuery, TermDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetTermQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<TermDto> Handle(GetTermQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, TermDto.Selector(), cancellationToken);
        }
    }
}
