using Msi.Mediator.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Contacts
{
    public class GetContactsQueryHandler : IQueryHandler<GetContactsQuery, IEnumerable<ContactDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetContactsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ContactDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            //var customerRole = await _unitOfWork.GetRepository<Role>()
            //    .FirstOrDefaultAsync(x => x.Code == "customer");

            //var q = _unitOfWork.GetRepository<UserRole>()
            //    .AsQueryable();

            //if(customerRole != null)
            //{
            //    q = q.Where(x => x.RoleId == customerRole.Id);
            //}

            //var results = q
            //    .Select(x => new CustomerDto
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
