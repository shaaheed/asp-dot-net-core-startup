using Core.Infrastructure.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Module.Organizations.Entities;
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

        public async Task<OrganizationDto> Handle(GetOrganizationQuery request, CancellationToken cancellationToken)
        {
            var org = _unitOfWork.GetRepository<Organization>()
                .AsQueryable()
                .Select(x => new OrganizationDto
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .FirstOrDefault(x => x.Id == request.Id);
            return await Task.FromResult(org);
        }
    }
}
