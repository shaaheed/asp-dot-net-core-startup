using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

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

        public Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, ContactDto.Selector(), cancellationToken);
        }
    }
}
