using Core.Infrastructure.Queries;
using Module.Users.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Vendors
{
    public class GetVendorQueryHandler : IQueryHandler<GetVendorQuery, VendorDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetVendorQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<VendorDto> Handle(GetVendorQuery request, CancellationToken cancellationToken)
        {
            var vendor = _unitOfWork.GetRepository<User>()
                .AsQueryable()
                .Select(x => new VendorDto
                {
                    Id = x.Id,
                    Name = x.FirstName,
                    Email = x.Email,
                    Mobile = x.Mobile,
                    Contact = x.Contact
                })
                .FirstOrDefault(x => x.Id == request.Id);
            return await Task.FromResult(vendor);
        }
    }
}
