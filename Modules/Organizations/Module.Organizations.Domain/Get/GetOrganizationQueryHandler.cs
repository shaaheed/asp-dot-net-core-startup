using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Organizations.Domain
{
    public class GetOrganizationQueryHandler : IQueryHandler<GetOrganizationQuery, OrganizationDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetOrganizationQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<OrganizationDto> Handle(GetOrganizationQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, OrganizationDto.Selector(), cancellationToken);
        }
    }
}
