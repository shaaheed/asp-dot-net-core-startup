using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Sales.Entities;
using System.Linq;

namespace Module.Sales.Domain.Contacts
{
    public class GetContactQueryHandler : IQueryHandler<GetContactQuery, ContactDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetContactQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var entity = _unitOfWork.GetRepository<Contact>()
                .AsQueryable()
                .Select(x => new ContactDto
                {
                    Id = x.Id,
                    Name = x.FirstName,
                    Email = x.Email,
                    Mobile = x.Mobile,
                    Contact = x.Contact
                })
                .FirstOrDefault(x => x.Id == request.Id);
            return await Task.FromResult(entity);
        }
    }
}
