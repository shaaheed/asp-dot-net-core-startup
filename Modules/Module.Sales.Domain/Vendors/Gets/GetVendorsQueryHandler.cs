using Core.Infrastructure.Queries;
using Module.Users.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.Vendors
{
    public class GetVendorsQueryHandler : IQueryHandler<GetVendorsQuery, IEnumerable<VendorDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetVendorsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VendorDto>> Handle(GetVendorsQuery request, CancellationToken cancellationToken)
        {
            var results = _unitOfWork.GetRepository<User>()
                .AsQueryable()
                .Select(x => new VendorDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.FirstName,
                    Mobile = x.Mobile,
                    Contact = x.Contact
                });
            return await Task.FromResult(results);
        }
    }
}
