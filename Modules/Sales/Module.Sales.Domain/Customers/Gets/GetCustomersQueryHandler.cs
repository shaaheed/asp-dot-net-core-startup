using Msi.Mediator.Abstractions;
using Module.Users.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Customers
{
    public class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, IEnumerable<CustomerDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetCustomersQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customerRole = await _unitOfWork.GetRepository<Role>()
                .FirstOrDefaultAsync(x => x.Code == "customer");

            var q = _unitOfWork.GetRepository<UserRole>()
                .AsQueryable();

            if(customerRole != null)
            {
                q = q.Where(x => x.RoleId == customerRole.Id);
            }

            var results = q
                .Select(x => new CustomerDto
                {
                    Id = x.User.Id,
                    Email = x.User.Email,
                    Name = x.User.FirstName,
                    Mobile = x.User.Mobile,
                    Contact = x.User.Contact
                })
                .ToList();
            return await Task.FromResult(results);
        }
    }
}
