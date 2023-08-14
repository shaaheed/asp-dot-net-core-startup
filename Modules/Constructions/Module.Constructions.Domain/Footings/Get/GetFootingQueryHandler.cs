using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Constructions.Domain
{
    public class GetFootingQueryHandler : IQueryHandler<GetFootingQuery, FootingDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetFootingQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<FootingDto> Handle(GetFootingQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, FootingDto.Selector(), cancellationToken);
        }
    }
}
