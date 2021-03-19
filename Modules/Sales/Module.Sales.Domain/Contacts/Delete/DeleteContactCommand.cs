using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Contacts
{
    public class DeleteContactCommand : ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
