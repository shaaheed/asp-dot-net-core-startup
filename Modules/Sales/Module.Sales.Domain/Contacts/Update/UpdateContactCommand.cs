using System;

namespace Module.Sales.Domain.Contacts
{
    public class UpdateContactCommand : CreateContactCommand
    {
        public Guid Id { get; set; }
    }
}
