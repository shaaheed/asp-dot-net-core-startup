using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Contacts
{
    public class GetContactQuery : IQuery<ContactDto>
    {
        public Guid Id { get; set; }
    }
}
