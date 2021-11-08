using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Integrations.Domain
{
    public class GetConnectorQueryHandler : IQueryHandler<GetConnectorQuery, ConnectorDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetConnectorQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ConnectorDto> Handle(GetConnectorQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, ConnectorDto.Selector(), cancellationToken);
        }
    }
}
