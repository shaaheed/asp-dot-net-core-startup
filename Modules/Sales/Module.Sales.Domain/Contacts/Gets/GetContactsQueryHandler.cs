using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Contacts
{
    public class GetContactsQueryHandler : IQueryHandler<GetContactsQuery, PagedCollection<ContactListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetContactsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<ContactListItemDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(ContactListItemDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
