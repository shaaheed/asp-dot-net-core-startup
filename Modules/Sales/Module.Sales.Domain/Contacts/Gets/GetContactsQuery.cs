using Msi.Mediator.Abstractions;
using System.Collections.Generic;

namespace Module.Sales.Domain.Contacts
{
    public class GetContactsQuery : IQuery<IEnumerable<ContactDto>>
    {
    }
}
