using Core.Infrastructure.Queries;
using Module.Users.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

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
            var results = _unitOfWork.GetRepository<User>()
                .AsQueryable()
                .Select(x => new CustomerDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.FirstName,
                    Mobile = x.Mobile,
                    Contact = x.Contact
                })
                .ToList();
            return await Task.FromResult(results);
        }
    }
}
