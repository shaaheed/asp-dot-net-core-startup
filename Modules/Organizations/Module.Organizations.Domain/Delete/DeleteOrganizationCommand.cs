using Msi.Mediator.Abstractions;
using System;

namespace Module.Organizations.Domain
{
    public class DeleteOrganizationCommand : ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
