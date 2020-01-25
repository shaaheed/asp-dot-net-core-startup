﻿using Core.Infrastructure.Queries;
using Module.Users.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.Customers
{
    public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, CustomerDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = _unitOfWork.GetRepository<User>()
                .AsQueryable()
                .Select(x => new CustomerDto
                {
                    Id = x.Id,
                    Name = x.FirstName,
                    Email = x.Email,
                    Mobile = x.Mobile,
                    Contact = x.Contact
                })
                .FirstOrDefault(x => x.Id == request.Id);
            return await Task.FromResult(customer);
        }
    }
}
