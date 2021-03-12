using Msi.Mediator.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

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
            //var customerRole = await _unitOfWork.GetRepository<Role>()
            //    .FirstOrDefaultAsync(x => x.Code == "vendor");

            //var q = _unitOfWork.GetRepository<UserRole>()
            //    .AsQueryable();

            //if (customerRole != null)
            //{
            //    q = q.Where(x => x.RoleId == customerRole.Id);
            //}

            //var results = q
            //    .Select(x => new VendorDto
            //    {
            //        Id = x.User.Id,
            //        Email = x.User.Email,
            //        Name = x.User.FirstName,
            //        Mobile = x.User.Mobile,
            //        Contact = x.User.Contact
            //    })
            //    .ToList();
            //return await Task.FromResult(results);
            return null;
        }
    }
}
