using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

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
            //var customer = _unitOfWork.GetRepository<User>()
            //    .AsQueryable()
            //    .Select(x => new CustomerDto
            //    {
            //        Id = x.Id,
            //        Name = x.FirstName,
            //        Email = x.Email,
            //        Mobile = x.Mobile,
            //        Contact = x.Contact
            //    })
            //    .FirstOrDefault(x => x.Id == request.Id);
            //return await Task.FromResult(customer);
            return null;
        }
    }
}
