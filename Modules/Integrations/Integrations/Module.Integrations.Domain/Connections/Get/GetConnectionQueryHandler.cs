using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Integrations.Domain
{
    public class GetConnectionQueryHandler : IQueryHandler<GetConnectionQuery, ConnectionDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetConnectionQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ConnectionDto> Handle(GetConnectionQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, ConnectionDto.Selector(), cancellationToken);
        }
    }
}
