using Msi.Mediator.Abstractions;
using System;

namespace Module.Organizations.Domain
{
    public class UpdateOrganizationCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
