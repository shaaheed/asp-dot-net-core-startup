using Core.Infrastructure.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Module.Organizations.Entities;
using Msi.Data.Abstractions;

namespace Module.Organizations.Domain
{
    public class GetOrganizationsQueryHandler : IQueryHandler<GetOrganizationsQuery, IEnumerable<OrganizationDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetOrganizationsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrganizationDto>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var results = _unitOfWork.GetRepository<Organization>()
                .AsQueryable()
                .Select(x => new OrganizationDto
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();
            return await Task.FromResult(results);
        }
    }
}
