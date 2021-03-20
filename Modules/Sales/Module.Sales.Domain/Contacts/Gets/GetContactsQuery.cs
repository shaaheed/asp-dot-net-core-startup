using Msi.Domain.Abstractions;
using Msi.Mediator.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Contacts
{
    public class GetContactsQuery : Query<PagedCollection<ContactListItemDto>>
    {
    }
}
